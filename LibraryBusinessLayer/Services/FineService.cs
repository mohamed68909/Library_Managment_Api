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

        public async Task< IEnumerable<FineDto>> GetFinesByUserAsync(int userId)
        {
            var Fines = await _repository.GetByUserIdAsync(userId);
           return Fines.Select(f => new FineDto
                {
                    FineID = f.FineId,
                    UserID = f.UserId,
                    BorrowingRecordID = f.BorrowingRecordId,
                    NumberOfLateDays = f.NumberOfLateDays,
                    FineAmount = f.FineAmount,
                    PaymentStatus = f.PaymentStatus
                });
        }

        public async Task< FineDto> GetFineByIdAsync(int id)
        {
            var fine =  await _repository.GetByIdAsync(id);
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

        public async Task<bool> UpdatePaymentStatusAsync(int fineId, bool status)
        {
            var fine =  await _repository.GetByIdAsync(fineId);
            if (fine == null) return false;

            fine.PaymentStatus = status;
            await _repository.UpdateAsync(fine);
            await _repository.SaveAsync();
            return true;
        }
    }

}
