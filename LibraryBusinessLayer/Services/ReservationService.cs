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

        public void Create(ReservationCreateDto dto)
        {
            var copy = _copyRepo.GetById(dto.CopyID);
            if (copy == null) throw new Exception("Version not found");
            if (copy.AvailabilityStatus == true)
                throw new Exception("An available copy cannot be reserved");

            var reservation = new Reservation
            {
                UserId = dto.UserID,
                CopyId = dto.CopyID,
                ReservationDate = DateTime.Now
            };

            _repo.Add(reservation);
            _repo.Save();
        }

        public void Cancel(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public List<ReservationDto> GetByUserId(int userId)
        {
            return _repo.GetByUserId(userId).Select(r => new ReservationDto
            {
                ReservationID = r.ReservationId,
                UserID = r.UserId,
                CopyID = r.CopyId,
                ReservationDate = r.ReservationDate
            }).ToList();
        }
    }

}
