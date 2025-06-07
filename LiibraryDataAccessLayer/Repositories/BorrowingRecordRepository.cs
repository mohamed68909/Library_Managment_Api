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

        public List<BorrowingRecord> GetByUser(int userId) =>
            _context.BorrowingRecords
                    .Include(r => r.Copy)
                    .Where(r => r.UserId == userId).ToList();

        public BorrowingRecord? GetById(int id) => _context.BorrowingRecords.Find(id);

        public void Add(BorrowingRecord record) => _context.BorrowingRecords.Add(record);

        public void Update(BorrowingRecord record) => _context.BorrowingRecords.Update(record);

        public void Save() => _context.SaveChanges();
    }

}
