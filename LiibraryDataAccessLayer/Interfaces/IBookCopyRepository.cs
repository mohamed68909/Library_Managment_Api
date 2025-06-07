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
        List<BookCopy> GetAll();
        List<BookCopy> GetByBookId(int bookId);
        BookCopy? GetById(int id);
        void Add(BookCopy copy);
        void Update(BookCopy copy);
        void Delete(int id);
        void Save();
    }
}
