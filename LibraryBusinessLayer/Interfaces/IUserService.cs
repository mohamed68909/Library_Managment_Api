using LiibraryDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto? GetById(int id);
      
        void Update(UserDto dto);
        void Delete(int id);
    }


}
