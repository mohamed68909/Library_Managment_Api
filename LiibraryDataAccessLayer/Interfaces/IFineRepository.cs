using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Interfaces
{
    public interface IFineRepository
    {
        IEnumerable<Fine> GetByUserId(int userId);
        Fine GetById(int id);
        void Update(Fine fine);
        void Save();
    }

}
