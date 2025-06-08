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
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repo;
        private readonly IBookCopyRepository _copyRepo;

        public ReservationService(IReservationRepository repo, IBookCopyRepository copyRepo)
        {
            _repo = repo;
            _copyRepo = copyRepo;
        }

        public async Task CreateAsync(ReservationCreateDto dto)
        {
            var copy = await _copyRepo.GetByIdAsync(dto.CopyID);
            if (copy == null) throw new Exception("Version not found");
            if (copy.AvailabilityStatus == true)
                throw new Exception("An available copy cannot be reserved");

            var reservation = new Reservation
            {
                UserId = dto.UserID,
                CopyId = dto.CopyID,
                ReservationDate = DateTime.Now
            };

           await _repo.AddAsync(reservation);
           await _repo.SaveAsync();
        }

        public async Task CancelAsync(int id)
        {
           await _repo.DeleteAsync(id);
          await  _repo.SaveAsync();
        }

        public  async Task <List<ReservationDto>> GetByUserIdAsync(int userId)
        {
            var Reser= await _repo.GetByUserIdAsync(userId);
             return Reser.Select(r => new ReservationDto
            {
                ReservationID = r.ReservationId,
                UserID = r.UserId,
                CopyID = r.CopyId,
                ReservationDate = r.ReservationDate
            }).ToList();
        }
    }

}
