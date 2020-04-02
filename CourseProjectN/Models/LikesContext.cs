using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourseProjectN.Models
{
    public class LikesContext : DbContext
    {
        public LikesContext() : base("DBConnection")
        {

        }

        public DbSet<Likes> Likes { get; set; }
    }
}