
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
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo) => _repo = repo;

        public List<BookDto> GetAll() => _repo.GetAll()
            .Select(book => new BookDto
            {
                BookID = book.BookId,
                Title = book.Title,
                ISBN = book.Isbn,
                PublicationDate = book.PublicationDate,
                Genre = book.Genre
            }).ToList();

        public BookDto? GetById(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return null;

            return new BookDto
            {
                BookID = book.BookId,
                Title = book.Title,
                ISBN = book.Isbn,
                PublicationDate = book.PublicationDate,
                Genre = book.Genre
            };
        }

        public void Create(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Isbn = dto.ISBN,
                PublicationDate = dto.PublicationDate,
                Genre = dto.Genre,
                AdditionalDetails = dto.AdditionalDetails
            };
            _repo.Add(book);
            _repo.Save();
        }

        public void Update(BookUpdateDto dto)
        {
            var book = _repo.GetById(dto.BookID);
            if (book == null) return;

            book.Title = dto.Title;
            book.Isbn = dto.ISBN;
            book.PublicationDate = dto.PublicationDate;
            book.Genre = dto.Genre;
            book.AdditionalDetails = dto.AdditionalDetails;

            _repo.Update(book);
            _repo.Save();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }

}
