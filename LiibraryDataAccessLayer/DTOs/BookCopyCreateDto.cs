using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.DTOs
{
    public class BookCopyCreateDto
    {
        public int BookID { get; set; }
        public bool AvailabilityStatus { get; set; }
    }
}
