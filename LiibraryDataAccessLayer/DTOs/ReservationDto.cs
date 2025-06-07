using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.DTOs
{
    public class ReservationDto
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public int CopyID { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
