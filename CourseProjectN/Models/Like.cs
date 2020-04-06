using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProjectN.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public int Count { get; set; }
    }
}