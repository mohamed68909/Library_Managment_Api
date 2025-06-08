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
        Task CreateAsync(ReservationCreateDto dto);
        Task CancelAsync(int id);
      Task < List<ReservationDto> >GetByUserIdAsync(int userId);
    }
}
