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
        void Register(UserRegisterDto dto);
        string Login(UserLoginDto dto);
    }
}
