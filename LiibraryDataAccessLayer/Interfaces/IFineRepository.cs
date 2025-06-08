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
      Task<  IEnumerable<Fine> >GetByUserIdAsync(int userId);
       Task< Fine> GetByIdAsync(int id);
        Task UpdateAsync(Fine fine);
        Task SaveAsync();
    }

}
