using DeleteLibrary.Models;
using System.Data.Entity;

namespace DeleteLibrary.Context
{
    public class LibraryContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<TakenBook> TakenBooks { get; set; }
        public DbSet<Role> Roles { get; set; }
    }

    //public class LibraryDbInit : DropCreateDatabaseAlways<LibraryContext>
    //{
    //    protected override void Seed(LibraryContext db)
    //    {
    //        db.Users.Add(new User
    //        {
    //            Login = "mino",
    //            Name = "Артур Губайдуллин",
    //            Password = "123"
    //        });
    //        db.Users.Add(new User
    //        {
    //            Login = "mino2",
    //            Name = "Иван",
    //            Password = "123"
    //        });
    //        db.Books.Add(new Book
    //        {
    //            Author = "Джеймс Чамберс",
    //            Cover = "https://habrastorage.org/web/c13/cad/8f9/c13cad8f9be748ed8a6f52871b3ac306.jpg",
    //            Name = "ASP.NET Core. Разработка приложений",
    //            Discription = "Мало кто из разработчиков доволен кодом, который они написали год назад. Расхожая шутка на многих семинарах по программированию: программист восклицает «Кто написал этот мусор?», заглядывает в историю и выясняет, что это был он. На самом деле это замечательная возможность. Приступая к написанию кода, часто вы только пытаетесь разобраться в предметной области, задаче программирования и структуре приложения, которое вам предстоит написать. Объем информации, которую разум может усвоить за один раз, ограничен, а большое количество «подвижных частей» часто приводит к ошибкам в структуре или функциональности кода. Вернуться и исправить старый код спустя несколько месяцев, когда ваше понимание приложения улучшилось, — величайшая роскошь."

    //        });
    //        db.Books.Add(new Book
    //        {
    //            Author = "Jess Chadwick ",
    //            Cover = "https://images-na.ssl-images-amazon.com/images/I/51dpPiy-OQL._SX377_BO1,204,203,200_.jpg",
    //            Name = "Programming Asp.Net Mvc 4",
    //            Discription = "Get up and running with ASP.NET MVC 4, and learn how to build modern server-side web applications. This guide helps you understand how the framework performs, and shows you how to use various features to solve many real-world development scenarios you’re likely to face. In the process, you’ll learn how to work with HTML, JavaScript, the Entity Framework, and other web technologies."

    //        });
    //        db.TakenBooks.Add(new TakenBook
    //        {
    //            BookId = 1,
    //            DateTake = DateTime.Now
    //        });
    //        base.Seed(db);
    //    }
    //}
}