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
        IEnumerable<FineDto> GetFinesByUser(int userId);
        FineDto GetFineById(int id);
        bool UpdatePaymentStatus(int fineId, bool status);
    }

}
