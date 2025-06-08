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
        Task BorrowAsync(BorrowRequestDto dto);
        Task ReturnAsync(int borrowingRecordId);
       Task< List<BorrowingRecordDto>> GetByUserAsync(int userId);
    }

}
