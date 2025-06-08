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
    public class BorrowingRecordRepository : IBorrowingRecordRepository
    {
        private readonly LibraryContext _context;
        public BorrowingRecordRepository(LibraryContext context) => _context = context;

        public async Task <List<BorrowingRecord>> GetByUserAsync(int userId) =>
          await  _context.BorrowingRecords
                    .Include(r => r.Copy)
                    .Where(r => r.UserId == userId).ToListAsync();

        public async Task <BorrowingRecord?> GetByIdAsync(int id) => await _context.BorrowingRecords.FindAsync(id);

        public async Task AddAsync(BorrowingRecord record) => await _context.BorrowingRecords.AddAsync(record);

        public Task UpdateAsync(BorrowingRecord BorrowingRecord)
        {
            _context.BorrowingRecords.Update(BorrowingRecord);
            return Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }

}
