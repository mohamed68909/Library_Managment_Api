using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.DTOs
{
    public class SettingsDto
    {
        public int DefualtBorrrowDays { get; set; }
        public int DefaultFinePerDay { get; set; }
    }
}
