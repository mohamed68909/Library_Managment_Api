using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.DTOs
{
    public class BookDto
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateOnly PublicationDate { get; set; }
        public string Genre { get; set; }
    }
    }

