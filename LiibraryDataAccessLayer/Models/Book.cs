using System;
using System.Collections.Generic;

namespace LiibraryDataAccessLayer.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public DateOnly PublicationDate { get; set; }

    public string Genre { get; set; } = null!;

    public string? AdditionalDetails { get; set; }

    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
}
