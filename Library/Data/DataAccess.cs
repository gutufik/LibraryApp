using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class DataAccess
    {
        public delegate void RefreshList();
        public static event RefreshList Refresh;
        public static List<Book> GetBooks()
        {
            return LibraryContext.GetContext().Books.ToList();
        }
        public static List<Reader> GetReaders()
        {
            return LibraryContext.GetContext().Readers.ToList();
        }
        public static List<BookTransfer> GetBookTransfers()
        {
            return LibraryContext.GetContext().BookTransfers
                .Include(bt => bt.TransferType)
                .Include(bt => bt.Reader)
                .Include(bt => bt.Book)
                .ToList();
        }
        public static List<TransferType> GetTransferTypes()
        {
            return LibraryContext.GetContext().TransferTypes.ToList();
        }

        internal static bool SaveBook(Book book)
        {
            try
            {
                if (GetBooks().FirstOrDefault(x => x.Id == book.Id) == null)
                    LibraryContext.GetContext().Books.Add(book);
                LibraryContext.GetContext().SaveChanges();
                Refresh?.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        internal static void DeleteBook(Book? book)
        {
            LibraryContext.GetContext().Books.Remove(book);
            LibraryContext.GetContext().SaveChanges();
            Refresh?.Invoke();
        }
    }
}
