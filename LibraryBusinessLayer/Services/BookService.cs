
using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo) => _repo = repo;

        public async Task<List<BookDto>> GetAllAsync()
        {
            var book = await _repo.GetAllAsync();
            return book.Select(book => new BookDto
            {
                BookID = book.BookId,
                Title = book.Title,
                ISBN = book.Isbn,
                PublicationDate = book.PublicationDate,
                Genre = book.Genre
            }).ToList();
        }

        public async Task< BookDto?> GetByIdAsync(int id)
        {
            var book =  await _repo.GetByIdAsync(id);
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

        public async Task CreateAsync(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Isbn = dto.ISBN,
                PublicationDate = dto.PublicationDate,
                Genre = dto.Genre,
                AdditionalDetails = dto.AdditionalDetails
            };
             await _repo.AddAsync(book);
          await  _repo.SaveAsync();
        }

        public async Task UpdateAsync(BookUpdateDto dto)
        {
            var book =  await _repo.GetByIdAsync(dto.BookID);
            if (book == null) return;

            book.Title = dto.Title;
            book.Isbn = dto.ISBN;
            book.PublicationDate = dto.PublicationDate;
            book.Genre = dto.Genre;
            book.AdditionalDetails = dto.AdditionalDetails;

           await _repo.UpdateAsync(book);
            await _repo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
           await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }
    }

}
