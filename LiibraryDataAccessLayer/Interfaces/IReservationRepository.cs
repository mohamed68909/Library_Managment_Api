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
        List<Reservation> GetByUserId(int userId);
        Reservation? GetById(int id);
        void Add(Reservation reservation);
        void Delete(int id);
        void Save();
    }
}
