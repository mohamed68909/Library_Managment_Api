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
        List<BookCopyDto> GetAll();
        List<BookCopyDto> GetByBookId(int bookId);
        BookCopyDto? GetById(int id);
        void Create(BookCopyCreateDto dto);
        void Update(BookCopyDto dto);
        void Delete(int id);
    }
}
