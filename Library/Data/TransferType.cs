using System;
using System.Collections.Generic;

namespace Library.Data
{
    public partial class TransferType
    {
        public TransferType()
        {
            BookTransfers = new HashSet<BookTransfer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BookTransfer> BookTransfers { get; set; }
    }
}
