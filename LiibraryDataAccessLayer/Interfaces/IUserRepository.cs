using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
       Task< List<User>> GetAllAsync();
      Task < User?> GetByIdAsync(int id);
   
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }


}
