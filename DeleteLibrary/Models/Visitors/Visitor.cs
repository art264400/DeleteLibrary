using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeleteLibrary.Models.Visitors
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public string Browser { get; set; }
        public DateTime Date { get; set; }
    }
}