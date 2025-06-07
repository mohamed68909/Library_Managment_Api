using System;
using System.Collections.Generic;

namespace LiibraryDataAccessLayer.Models;

public class Setting
{
    public int SettingsId { get; set; }
    public int UserId { get; set; } 

    public int DefaultBorrowDays { get; set; }
    public int DefaultFinePerDay { get; set; }

    public User User { get; set; } 
}

