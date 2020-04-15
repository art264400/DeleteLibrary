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
        Book[] GetListFreeBooks();


        User[] GetAllUsers();
        User GetUserById(int id);
        User GetUserByLogin(string login);
        bool CreateUser(User newUser);
        bool RemoveUserById(int id);
        bool UpdateUser(User updateUser);
        User GetUserByLoginModel(LoginModel loginModel);

        bool CreateTakenBook(TakenBook newTakenBook);
        TakenBook[] GetAllTakenBooks();
        TakenBook[] GetTakenBooksByUserId(int id);
        TakenBook[] GetReservedTakenBooksByUserId(int id);
        TakenBook[] GetAllOnDeletedTakenBooks();
        TakenBook GetTakenBookById(int id);
        TakenBook GetTakenBookByBookId(int bookId);
        bool RemoveTakenBookByBookId(int bookId);
        bool ReturnTakenBookById(int id);
        bool UpdateTakenBook(TakenBook updateTakenBook);
        bool RemoveReservedAtTakenBookById(int id);
        


    }
}