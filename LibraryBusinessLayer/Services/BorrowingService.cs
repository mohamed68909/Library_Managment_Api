using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRecordRepository _repo;
        private readonly IBookCopyRepository _copyRepo;
        private readonly ISettingsRepository _settingsRepo;

        public BorrowingService(
            IBorrowingRecordRepository repo,
            IBookCopyRepository copyRepo,
            ISettingsRepository settingsRepo)
        {
            _repo = repo;
            _copyRepo = copyRepo;
            _settingsRepo = settingsRepo;
        }

        public void Borrow(BorrowRequestDto dto)
        {
            var copy = _copyRepo.GetById(dto.CopyID);
            if (copy == null) throw new Exception("Copy not found");
            if (!copy.AvailabilityStatus) throw new Exception("Version not available");

            var settings = _settingsRepo.GetSettings();

            var record = new BorrowingRecord
            {
                UserId = dto.UserID,
                CopyId = dto.CopyID,
                BorrowingDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(settings.DefaultBorrowDays)
            };

            copy.AvailabilityStatus = false;
            _copyRepo.Update(copy);

            _repo.Add(record);
            _repo.Save();
            _copyRepo.Save();
        }

        public void Return(int id)
        {
            var record = _repo.GetById(id);
            if (record == null || record.ActualReturnDate != null)
                throw new Exception("Invalid or previously returned record");

            record.ActualReturnDate = DateTime.Now;

            var copy = _copyRepo.GetById(record.CopyId);
            if (copy != null)
            {
                copy.AvailabilityStatus = true;
                _copyRepo.Update(copy);
            }

            _repo.Update(record);
            _repo.Save();
            _copyRepo.Save();
        }

        public List<BorrowingRecordDto> GetByUser(int userId)
        {
            return _repo.GetByUser(userId).Select(r => new BorrowingRecordDto
            {
                BorrowingRecordID = r.BorrowingRecordId,
                UserID = r.UserId,
                CopyID = r.CopyId,
                BorrowingDate = r.BorrowingDate,
                DueDate = r.DueDate,
                ActualReturnDate = r.ActualReturnDate
            }).ToList();
        }
    }

}
