using DeleteLibrary.Models;

namespace DeleteLibrary.Interfaces
{
    public interface IlibraryService
    {
        Book[] GetAllBooks();
        Book GetBookById(int id);
        bool CreateBook(Book newBook);
        bool RemoveBookById(int id);
        bool UpdateBook(Book updateBook);
    }
}