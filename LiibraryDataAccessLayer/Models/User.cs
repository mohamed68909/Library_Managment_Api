using System;
using System.Collections.Generic;

namespace LiibraryDataAccessLayer.Models;

public partial class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string ContactInformation { get; set; } = null!;
    public string LibraryCardNumber { get; set; } = null!;

    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Setting settings { get; set; }

    public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new List<BorrowingRecord>();
    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

