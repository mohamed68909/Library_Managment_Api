using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using LiibraryDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Services
{
    public class FineService : IFineService
    {
        private readonly IFineRepository _repository;

        public FineService(IFineRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<FineDto> GetFinesByUser(int userId)
        {
            return _repository.GetByUserId(userId)
                .Select(f => new FineDto
                {
                    FineID = f.FineId,
                    UserID = f.UserId,
                    BorrowingRecordID = f.BorrowingRecordId,
                    NumberOfLateDays = f.NumberOfLateDays,
                    FineAmount = f.FineAmount,
                    PaymentStatus = f.PaymentStatus
                });
        }

        public FineDto GetFineById(int id)
        {
            var fine = _repository.GetById(id);
            if (fine == null) return null;

            return new FineDto
            {
                FineID = fine.FineId,
                UserID = fine.UserId,
                BorrowingRecordID = fine.BorrowingRecordId,
                NumberOfLateDays = fine.NumberOfLateDays,
                FineAmount = fine.FineAmount,
                PaymentStatus = fine.PaymentStatus
            };
        }

        public bool UpdatePaymentStatus(int fineId, bool status)
        {
            var fine = _repository.GetById(fineId);
            if (fine == null) return false;

            fine.PaymentStatus = status;
            _repository.Update(fine);
            _repository.Save();
            return true;
        }
    }

}
