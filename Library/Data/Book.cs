using System;
using System.Collections.Generic;

namespace Library.Data
{
    public partial class Book
    {
        public Book()
        {
            BookTransfers = new HashSet<BookTransfer>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;

        public virtual ICollection<BookTransfer> BookTransfers { get; set; }
    }
}
