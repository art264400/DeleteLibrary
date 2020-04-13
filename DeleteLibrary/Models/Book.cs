using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeleteLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
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