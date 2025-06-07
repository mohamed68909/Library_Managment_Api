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

        public List<BookCopy> GetAll() => _context.BookCopies.Include(c => c.Book).ToList();

        public List<BookCopy> GetByBookId(int bookId) =>
            _context.BookCopies.Where(c => c.BookId == bookId).ToList();

        public BookCopy? GetById(int id) => _context.BookCopies.Find(id);

        public void Add(BookCopy copy) => _context.BookCopies.Add(copy);

        public void Update(BookCopy copy) => _context.BookCopies.Update(copy);

        public void Delete(int id)
        {
            var copy = _context.BookCopies.Find(id);
            if (copy != null) _context.BookCopies.Remove(copy);
        }

        public void Save() => _context.SaveChanges();
    }

}
