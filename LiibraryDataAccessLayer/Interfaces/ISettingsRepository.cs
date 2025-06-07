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
        Setting GetSettings();
        void Update(Setting settings);
        void Save();
    }

}
