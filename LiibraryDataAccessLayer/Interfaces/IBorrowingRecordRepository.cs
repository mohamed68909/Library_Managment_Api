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
        List<BorrowingRecord> GetByUser(int userId);
        BorrowingRecord? GetById(int id);
        void Add(BorrowingRecord record);
        void Update(BorrowingRecord record);
        void Save();
    }

}
