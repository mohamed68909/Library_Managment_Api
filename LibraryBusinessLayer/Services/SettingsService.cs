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

        public SettingsDto Get()
        {
            var settings = _repo.GetSettings();
            return new SettingsDto
            {
                DefualtBorrrowDays = settings.DefaultBorrowDays,
                DefaultFinePerDay = settings.DefaultFinePerDay
            };
        }

        public void Update(SettingsDto dto)
        {
            var settings = _repo.GetSettings();
            settings.DefaultBorrowDays = dto.DefualtBorrrowDays;
            settings.DefaultFinePerDay = dto.DefaultFinePerDay;

            _repo.Update(settings);
            _repo.Save();
        }
    }
}
