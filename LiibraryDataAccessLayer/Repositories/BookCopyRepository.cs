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
    public class BookCopyRepository : IBookCopyRepository
    {
        private readonly LibraryContext _context;
        public BookCopyRepository(LibraryContext context) => _context = context;

        public async Task< List<BookCopy>> GetAllAsync() => await _context.BookCopies.Include(c => c.Book).ToListAsync();

        public async Task< List<BookCopy>> GetByBookIdAsync(int bookId) =>
          await  _context.BookCopies.Where(c => c.BookId == bookId).ToListAsync();

        public  async Task<BookCopy?> GetByIdAsync(int id) => await _context.BookCopies.FindAsync(id);

        public async Task AddAsync(BookCopy copy) => await _context.BookCopies.AddAsync(copy);

        public Task UpdateAsync(BookCopy BookCopy)
        {
            _context.BookCopies.Update(BookCopy);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var copy = await _context.BookCopies.FindAsync(id);
            if (copy != null) _context.BookCopies.Remove(copy);
        }

        public async Task SaveAsync() =>  await _context.SaveChangesAsync();
    }

}
