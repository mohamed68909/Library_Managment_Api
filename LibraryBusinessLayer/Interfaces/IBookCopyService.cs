using LiibraryDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Interfaces
{
    public interface IBookCopyService
    {
      Task<  List<BookCopyDto>> GetAllAsync();
      Task  <List<BookCopyDto>> GetByBookIdAsync(int bookId);
      Task < BookCopyDto?> GetByIdAsync(int id);
        Task CreateAsync(BookCopyCreateDto dto);
        Task UpdateAsync(BookCopyDto dto);
        Task DeleteAsync(int id);
    }
}
