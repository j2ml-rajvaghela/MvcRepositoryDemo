using MvcRepositoryPatternDemo.Models;

namespace MvcRepositoryPatternDemo.DAL
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(long Bookid);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(long Bookid);
        void Save();
    }
}
