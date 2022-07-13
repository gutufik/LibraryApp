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

        internal static bool SaveReader(Reader reader)
        {
            try
            {
                if (GetReaders().FirstOrDefault(x => x.Id == reader.Id) == null)
                    LibraryContext.GetContext().Readers.Add(reader);
                LibraryContext.GetContext().SaveChanges();
                Refresh?.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static bool SaveTransfer(BookTransfer transfer)
        {
            try
            {
                if (GetBookTransfers().FirstOrDefault(x => x.Id == transfer.Id) == null)
                    LibraryContext.GetContext().BookTransfers.Add(transfer);
                LibraryContext.GetContext().SaveChanges();
                Refresh?.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static void DeleteTransfer(BookTransfer? transfer)
        {
            LibraryContext.GetContext().BookTransfers.Remove(transfer);
            LibraryContext.GetContext().SaveChanges();
            Refresh?.Invoke();
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

        internal static void DeleteReader(Reader? reader)
        {
            LibraryContext.GetContext().Readers.Remove(reader);
            LibraryContext.GetContext().SaveChanges();
            Refresh?.Invoke();
        }
    }
}
