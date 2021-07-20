using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models
{
    class MyDBContext : DbContext
    {
        public MyDBContext() : base("MyDBConnectionString")
        {

        }

        public DbSet<Detail> Details { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
