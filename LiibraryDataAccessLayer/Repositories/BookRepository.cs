using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
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

        public List<Book> GetAll() => _context.Books.ToList();

        public Book? GetById(int id) => _context.Books.Find(id);

        public void Add(Book book) => _context.Books.Add(book);

        public void Update(Book book) => _context.Books.Update(book);

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null) _context.Books.Remove(book);
        }

        public void Save() => _context.SaveChanges();
    }

}
