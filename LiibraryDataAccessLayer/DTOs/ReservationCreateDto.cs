using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.DTOs
{
    public class ReservationCreateDto
    {
        public int UserID { get; set; }
        public int CopyID { get; set; }
    }

}
