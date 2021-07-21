namespace CRUD.Migrations
{
    using CRUD.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUD.Models.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRUD.Models.MyDBContext context)
        {
            //This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            IList<Detail> defaultDetail = new List<Detail>();
            
            defaultDetail.Add(new Detail() { FName = "Harry1", LName = "Potter1" ,Address = "Secret1",Age = 20,DOB = DateTime.Now});
            defaultDetail.Add(new Detail() { FName = "Harry2", LName = "Potter2", Address = "Secret2", Age = 20, DOB = DateTime.Now });
            defaultDetail.Add(new Detail() { FName = "Harry3", LName = "Potter3", Address = "Secret3", Age = 20, DOB = DateTime.Now });

            context.Details.AddRange(defaultDetail);

            base.Seed(context);
        }
    }
}
