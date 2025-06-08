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
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context) => _context = context;

        public async Task<List<Book>> GetAllAsync() =>
     await _context.Books.ToListAsync();

        public async Task<Book?> GetByIdAsync(int id) =>
            await _context.Books.FindAsync(id);

        public async Task AddAsync(Book book) =>
            await _context.Books.AddAsync(book);

        public Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null) _context.Books.Remove(book);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();


    }
}
