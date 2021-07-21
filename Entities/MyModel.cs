using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CRUD.Entities
{
    public partial class MyModel : DbContext
    {
        public MyModel()
            : base("MyDBConnectionString")
        {
        }

        public virtual DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
