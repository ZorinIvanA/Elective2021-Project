using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Infrastructure
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<BookDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<BookDTO> Books { get; set; }
    }
}
