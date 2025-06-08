using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Interfaces
{
    public interface IReservationRepository
    {
       Task< List<Reservation>> GetByUserIdAsync(int userId);
       Task< Reservation?> GetByIdAsync(int id);
        Task AddAsync(Reservation reservation);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
