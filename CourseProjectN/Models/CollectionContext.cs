using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CourseProjectN.Models
{
    public class CollectionContext : DbContext
    {
        public CollectionContext()
            : base("DBConnection")
        { }

        public DbSet<Collections> Collections { get; set; }
    }
}