using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string LibraryCardNumber { get; set; }
        public string Username { get; set; }
    }

}
