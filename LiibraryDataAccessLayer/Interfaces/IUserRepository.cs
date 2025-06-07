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
        List<User> GetAll();
        User? GetById(int id);
   
        void Update(User user);
        void Delete(int id);
        void Save();
    }


}
