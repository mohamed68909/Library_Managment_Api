using LiibraryDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Interfaces
{
    public interface IFineService
    {
       Task< IEnumerable<FineDto>> GetFinesByUserAsync(int userId);
      Task<  FineDto >GetFineByIdAsync(int id);
       Task< bool> UpdatePaymentStatusAsync(int fineId, bool status);
    }

}
