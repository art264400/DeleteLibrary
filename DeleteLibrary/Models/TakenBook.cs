using System;
namespace DeleteLibrary.Models
{
    public class TakenBook
    {
        public int Id { get; set; }
        public DateTime? DateTake { get; set; }
        public DateTime? DateReturn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsReserved { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public TakenBook()
        {
            IsDeleted = false;
            IsReserved = false;
            UserId = 1;
        }
    }
}