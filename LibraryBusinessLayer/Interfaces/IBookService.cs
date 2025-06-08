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
       Task< List<BookDto>> GetAllAsync();
       Task< BookDto?> GetByIdAsync(int id);
        Task CreateAsync(BookCreateDto dto);
        Task UpdateAsync(BookUpdateDto dto);
        Task DeleteAsync(int id);
    }

}
