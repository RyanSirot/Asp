namespace ZenithWebSite.Migrations.IdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\IdentityMigrations";
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context)
        {
            setRoles(context);
            context.SaveChanges();
            setUsers(context);
            context.SaveChanges();
            context.Activities.AddOrUpdate(a => a.Id, getActivity());
            context.SaveChanges();
            context.Events.AddOrUpdate(e => e.Id, getEvent(context));
            context.SaveChanges();

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

        private void setRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Member" };

                manager.Create(role);
            }
        }

        private void setUsers(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "a"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "a", Email = "a@a.a" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "m"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "m", Email = "m@m.m" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Member");
            }
        }

        private Activity[] getActivity()
        {
            var activity = new List<Activity>
            {
                new Activity()
                {
                    Description = "Soccer",
                    CreationDate = new DateTime(1960, 1, 1)
                },new Activity()
                {
                    Description = "Football",
                    CreationDate = new DateTime(1980, 1, 1)
                },new Activity()
                {
                    Description = "Ultimate Frisbee",
                    CreationDate = new DateTime(2001, 1, 1)
                }
            };
            return activity.ToArray();
        }

        private Event[] getEvent(ApplicationDbContext context)
        {
            var events = new List<Event>
            {
                new Event()
                {
                    FromDateTime = new DateTime(2017, 1, 1),
                    ToDateTime = new DateTime(2018, 1, 1),
                    Username = "SoccerFan1000",
                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Soccer").Id,
                    CreationDate = new DateTime(1960, 1, 1),
                    IsActive = true
                },new Event()
                {
                    FromDateTime = new DateTime(2017, 1, 1),
                    ToDateTime = new DateTime(2018, 1, 1),
                    Username = "FootballFan2000",
                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Football").Id,
                    CreationDate = new DateTime(1980, 1, 1),
                    IsActive = true
                },new Event()
                {
                    FromDateTime = new DateTime(2017, 1, 1),
                    ToDateTime = new DateTime(2018, 1, 1),
                    Username = "Ultimate_Frisbee420NoScope",
                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Ultimate Frisbee").Id,
                    CreationDate = new DateTime(2001, 1, 1),
                    IsActive = true
                }
            };
            return events.ToArray();
        }
    }
}
