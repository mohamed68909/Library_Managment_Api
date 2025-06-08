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
    public class FineRepository : IFineRepository
    {
        private readonly LibraryContext _context;

        public FineRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fine>> GetByUserIdAsync(int userId)
        {
            return  await _context.Fines.Where(f => f.UserId == userId).ToListAsync();
        }

        public  async Task<Fine> GetByIdAsync(int id)
        {
            return await _context.Fines.FindAsync(id);
        }

        public Task UpdateAsync(Fine Fine)
        {
            _context.Fines.Update(Fine);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
             await _context.SaveChangesAsync();
        }
    }

}
