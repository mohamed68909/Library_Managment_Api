using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.DTOs
{
    public class FineDto
    {
        public int FineID { get; set; }
        public int UserID { get; set; }
        public int BorrowingRecordID { get; set; }
        public short NumberOfLateDays { get; set; }
        public decimal FineAmount { get; set; }
        public bool PaymentStatus { get; set; }
    }

    public class FinePaymentDto
    {
        public bool PaymentStatus { get; set; }
    }

}
