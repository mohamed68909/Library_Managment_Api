using LiibraryDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        BookDto? GetById(int id);
        void Create(BookCreateDto dto);
        void Update(BookUpdateDto dto);
        void Delete(int id);
    }

}
