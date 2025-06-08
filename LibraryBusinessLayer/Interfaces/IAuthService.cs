using LiibraryDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(UserRegisterDto dto);
       Task< string> LoginAsync(UserLoginDto dto);
    }
}
