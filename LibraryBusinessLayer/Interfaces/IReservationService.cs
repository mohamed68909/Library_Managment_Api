using LiibraryDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Interfaces
{
    public interface IReservationService
    {
        void Create(ReservationCreateDto dto);
        void Cancel(int id);
        List<ReservationDto> GetByUserId(int userId);
    }
}
