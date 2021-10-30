using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Infrastructure
{
    public partial class BooksRead
    {
        public Guid Id { get; set; }
        public int? BookId { get; set; }
        public string Reader { get; set; }

        public virtual BookDTO Book { get; set; }
    }
}
