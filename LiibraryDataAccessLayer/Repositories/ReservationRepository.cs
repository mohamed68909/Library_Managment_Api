using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly LibraryContext _context;
        public ReservationRepository(LibraryContext context) => _context = context;

        public List<Reservation> GetByUserId(int userId) =>
            _context.Reservations.Include(r => r.Copy).Where(r => r.UserId == userId).ToList();

        public Reservation? GetById(int id) => _context.Reservations.Find(id);

        public void Add(Reservation reservation) => _context.Reservations.Add(reservation);

        public void Delete(int id)
        {
            var res = _context.Reservations.Find(id);
            if (res != null) _context.Reservations.Remove(res);
        }

        public void Save() => _context.SaveChanges();
    }

}
