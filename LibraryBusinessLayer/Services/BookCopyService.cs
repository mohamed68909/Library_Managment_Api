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

        public async Task<List<BookCopyDto>> GetAllAsync()
        {
            var Copy = await _repo.GetAllAsync();
           return  Copy.Select(c => new BookCopyDto
            {
                CopyID = c.CopyId,
                BookID = c.BookId,
                AvailabilityStatus = c.AvailabilityStatus
            }).ToList();
        }

        public async Task<List<BookCopyDto>> GetByBookIdAsync(int bookId)
        {
            var Copy = await _repo.GetByBookIdAsync(bookId); return Copy.Select(c => new BookCopyDto
            {
                CopyID = c.CopyId,
                BookID = c.BookId,
                AvailabilityStatus = c.AvailabilityStatus
            }).ToList();
        }

        public async Task< BookCopyDto?> GetByIdAsync(int id)
        {
            var copy = await _repo.GetByIdAsync(id);
            return copy == null ? null : new BookCopyDto
            {
                CopyID = copy.CopyId,
                BookID = copy.BookId,
                AvailabilityStatus = copy.AvailabilityStatus
            };
        }

        public async Task CreateAsync(BookCopyCreateDto dto)
        {
            var copy = new BookCopy
            {
                BookId = dto.BookID,
                AvailabilityStatus = dto.AvailabilityStatus
            };
           await _repo.AddAsync(copy);
           await _repo.SaveAsync();
        }

        public async Task UpdateAsync(BookCopyDto dto)
        {
            var copy = await _repo.GetByIdAsync(dto.CopyID);
            if (copy == null) return;

            copy.BookId = dto.BookID;
            copy.AvailabilityStatus = dto.AvailabilityStatus;
             await _repo.UpdateAsync(copy);
           await  _repo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
           await _repo.DeleteAsync(id);
          await  _repo.SaveAsync();
        }
    }
}
