using MvcRepositoryPatternDemo.Models;
using System.Net;

namespace MvcRepositoryPatternDemo.DAL
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookById(long bookId)
        {
            return _context.Books.Find(bookId);
        }
        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void DeleteBook(long bookId)
        {
            Book book = _context.Books.Find(bookId);
            _context.Books.Remove(book);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
               if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
