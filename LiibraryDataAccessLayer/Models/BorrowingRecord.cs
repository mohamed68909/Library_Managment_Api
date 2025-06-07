using System;
using System.Collections.Generic;

namespace LiibraryDataAccessLayer.Models;

public partial class BorrowingRecord
{
    public int BorrowingRecordId { get; set; }

    public int UserId { get; set; }

    public int CopyId { get; set; }

    public DateTime BorrowingDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ActualReturnDate { get; set; }

    public virtual BookCopy Copy { get; set; } = null!;

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual User User { get; set; } = null!;
}
