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
      Task< List<UserDto>> GetAllAsync();
      Task  <UserDto?> GetByIdAsync(int id);
      
        Task UpdateAsync(UserDto dto);
        Task DeleteAsync(int id);
    }


}
