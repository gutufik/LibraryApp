using System;
using System.Collections.Generic;

namespace Library.Data
{
    public partial class BookTransfer
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public int TransferTypeId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Reader Reader { get; set; } = null!;
        public virtual TransferType TransferType { get; set; } = null!;
    }
}
