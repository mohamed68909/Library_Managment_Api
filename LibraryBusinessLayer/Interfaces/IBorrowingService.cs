using LiibraryDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Interfaces
{
    public interface IBorrowingService
    {
        void Borrow(BorrowRequestDto dto);
        void Return(int borrowingRecordId);
        List<BorrowingRecordDto> GetByUser(int userId);
    }

}
