using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short? PublishedYear { get; set; }
        public short? PagesCount { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
