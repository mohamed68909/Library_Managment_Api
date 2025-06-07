using System;
using System.Collections.Generic;

namespace LiibraryDataAccessLayer.Models;

public partial class BookCopy
{
    public int CopyId { get; set; }

    public int BookId { get; set; }

    public bool AvailabilityStatus { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new List<BorrowingRecord>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
