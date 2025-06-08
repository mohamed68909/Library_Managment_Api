using LiibraryDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Interfaces
{
    public interface ISettingsService
    {
      Task  <SettingsDto> GetAsync();
        Task UpdateAsync(SettingsDto dto);
    }

}
