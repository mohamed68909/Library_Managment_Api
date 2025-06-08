using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Interfaces
{
    public interface IBorrowingRecordRepository
    {
         Task<List<BorrowingRecord>> GetByUserAsync(int userId);
        Task<BorrowingRecord?> GetByIdAsync(int id);
        Task AddAsync(BorrowingRecord record);
        Task UpdateAsync(BorrowingRecord record);
        Task SaveAsync();
    }

}
