using System.Collections.Generic;
using API.Models;
using API.Models.DbContexts;
using API.Services;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<API.Models.DbContexts.BerthaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            Database.SetInitializer(new DropCreateDatabaseAlways<BerthaContext>());
        }

        protected override void Seed(API.Models.DbContexts.BerthaContext context)
        {
            
            context.Database.Connection.Close();
            Database.SetInitializer(new DropCreateDatabaseAlways<BerthaContext>());
            var db = new BerthaContext();
            db.Database.Initialize(true);

            var rs = new RoleStore<IdentityRole>(context);
            var rm = new RoleManager<IdentityRole>(rs);
            var r = new IdentityRole("Admin");
            rm.Create(r);

            //um.Create(u, "password");

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
