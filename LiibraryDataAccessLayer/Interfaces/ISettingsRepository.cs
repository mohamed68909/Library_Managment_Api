using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Interfaces
{
    public interface ISettingsRepository
    {
        Task<Setting> GetSettingsAsync();
        Task UpdateAsync(Setting settings);
        Task SaveAsync();
    }

}
