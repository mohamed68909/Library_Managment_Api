using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Interfaces
{
    public interface IBookCopyRepository
    {
       Task< List<BookCopy> >GetAllAsync();
       Task< List<BookCopy>> GetByBookIdAsync(int bookId);
        Task<BookCopy?> GetByIdAsync(int id);
        Task AddAsync(BookCopy copy);
        Task UpdateAsync(BookCopy copy);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
