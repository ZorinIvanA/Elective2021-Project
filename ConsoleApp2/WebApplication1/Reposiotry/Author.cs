using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<BookDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<BookDTO> Books { get; set; }
    }
}
