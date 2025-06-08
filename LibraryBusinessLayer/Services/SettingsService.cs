using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using LiibraryDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Services
{

    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _repo;
        public SettingsService(ISettingsRepository repo) => _repo = repo;

        public async Task< SettingsDto> GetAsync()
        {
            var settings = await _repo.GetSettingsAsync();
            return new SettingsDto
            {
                DefualtBorrrowDays = settings.DefaultBorrowDays,
                DefaultFinePerDay = settings.DefaultFinePerDay
            };
        }

        public async Task UpdateAsync(SettingsDto dto)
        {
            var settings = await _repo.GetSettingsAsync();
            settings.DefaultBorrowDays = dto.DefualtBorrrowDays;
            settings.DefaultFinePerDay = dto.DefaultFinePerDay;

           await  _repo.UpdateAsync(settings);
         await   _repo.SaveAsync();
        }
    }
}
