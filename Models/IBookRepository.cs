using System.Collections.Generic;

namespace BookStore.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int bookId);

        void AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(Book book);
    }
}
