using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task< Setting>  GetSettingsAsync()
        {
            return await _context.Settings.FirstAsync(); // Assuming one row only
        }

        public  Task UpdateAsync(Setting settings)
        {
             _context.Settings.Update(settings);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
           await  _context.SaveChangesAsync();
        }
    }

}
