using System;
using System.Collections.Generic;

namespace Library.Data
{
    public partial class Reader
    {
        public Reader()
        {
            BookTransfers = new HashSet<BookTransfer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<BookTransfer> BookTransfers { get; set; }
    }
}
