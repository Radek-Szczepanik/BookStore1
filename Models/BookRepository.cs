using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddBook(Book book)
        {
            _appDbContext.Books.Add(book);
            _appDbContext.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();
        }

        public void EditBook(Book book)
        {
            _appDbContext.Update(book);
            _appDbContext.SaveChanges();
        }

        public Book GetBook(int bookId)
        {
            return _appDbContext.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _appDbContext.Books;
        }
    }
}
