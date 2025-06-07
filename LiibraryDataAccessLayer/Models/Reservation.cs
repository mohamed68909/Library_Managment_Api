using System;
using System.Collections.Generic;

namespace LiibraryDataAccessLayer.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int UserId { get; set; }

    public int CopyId { get; set; }

    public DateTime ReservationDate { get; set; }

    public virtual BookCopy Copy { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
