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

        public async Task< List<Reservation>> GetByUserIdAsync(int userId) =>
        await    _context.Reservations.Include(r => r.Copy).Where(r => r.UserId == userId).ToListAsync();

        public async Task<Reservation?> GetByIdAsync(int id) => await _context.Reservations.FindAsync(id);

        public async Task AddAsync(Reservation reservation) => await _context.Reservations.AddAsync(reservation);

        public async Task DeleteAsync(int id)
        {
            var res = await _context.Reservations.FindAsync(id);
            if (res != null)  _context.Reservations.Remove(res);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }

}
