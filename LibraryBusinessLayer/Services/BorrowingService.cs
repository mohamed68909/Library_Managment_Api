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

        public async Task BorrowAsync(BorrowRequestDto dto)
        {
            var copy =  await _copyRepo.GetByIdAsync(dto.CopyID);
            if (copy == null) throw new Exception("Copy not found");
            if (!copy.AvailabilityStatus) throw new Exception("Version not available");

            var settings = await _settingsRepo.GetSettingsAsync();

            var record = new BorrowingRecord
            {
                UserId = dto.UserID,
                CopyId = dto.CopyID,
                BorrowingDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(settings.DefaultBorrowDays)
            };

            copy.AvailabilityStatus = false;
           await _copyRepo.UpdateAsync(copy);

           await _repo.AddAsync(record);
           await _repo.SaveAsync();
           await  _copyRepo.SaveAsync();
        }

        public async Task ReturnAsync(int id)
        {
            var record = await _repo.GetByIdAsync(id);
            if (record == null || record.ActualReturnDate != null)
                throw new Exception("Invalid or previously returned record");

            record.ActualReturnDate = DateTime.Now;

            var copy = await _copyRepo.GetByIdAsync(record.CopyId);
            if (copy != null)
            {
                copy.AvailabilityStatus = true;
               await _copyRepo.UpdateAsync(copy);
            }

            await _repo.UpdateAsync(record);
            await _repo.SaveAsync();
            await _copyRepo.SaveAsync();
        }

        public async Task< List<BorrowingRecordDto>> GetByUserAsync(int userId)
        {
            var Record = await _repo.GetByUserAsync(userId);
            return Record.Select(r => new BorrowingRecordDto
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
