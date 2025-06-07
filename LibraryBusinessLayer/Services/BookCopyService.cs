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

    public class BookCopyService : IBookCopyService
    {
        private readonly IBookCopyRepository _repo;
        public BookCopyService(IBookCopyRepository repo) => _repo = repo;

        public List<BookCopyDto> GetAll() =>
            _repo.GetAll().Select(c => new BookCopyDto
            {
                CopyID = c.CopyId,
                BookID = c.BookId,
                AvailabilityStatus = c.AvailabilityStatus
            }).ToList();

        public List<BookCopyDto> GetByBookId(int bookId) =>
            _repo.GetByBookId(bookId).Select(c => new BookCopyDto
            {
                CopyID = c.CopyId,
                BookID = c.BookId,
                AvailabilityStatus = c.AvailabilityStatus
            }).ToList();

        public BookCopyDto? GetById(int id)
        {
            var copy = _repo.GetById(id);
            return copy == null ? null : new BookCopyDto
            {
                CopyID = copy.CopyId,
                BookID = copy.BookId,
                AvailabilityStatus = copy.AvailabilityStatus
            };
        }

        public void Create(BookCopyCreateDto dto)
        {
            var copy = new BookCopy
            {
                BookId = dto.BookID,
                AvailabilityStatus = dto.AvailabilityStatus
            };
            _repo.Add(copy);
            _repo.Save();
        }

        public void Update(BookCopyDto dto)
        {
            var copy = _repo.GetById(dto.CopyID);
            if (copy == null) return;

            copy.BookId = dto.BookID;
            copy.AvailabilityStatus = dto.AvailabilityStatus;
            _repo.Update(copy);
            _repo.Save();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
