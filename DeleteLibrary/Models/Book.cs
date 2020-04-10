using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleteLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Discription { get; set; }
        
        public bool IsDeleted { get; set; }
        public Book()
        {
            IsDeleted = false;
        }
    }
}