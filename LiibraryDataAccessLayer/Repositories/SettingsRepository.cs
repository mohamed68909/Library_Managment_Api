using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly LibraryContext _context;
        public SettingsRepository(LibraryContext context) => _context = context;

        public Setting GetSettings()
        {
            return _context.Settings.First(); // Assuming one row only
        }

        public void Update(Setting settings)
        {
            _context.Settings.Update(settings);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
