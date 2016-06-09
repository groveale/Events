namespace EventsP1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EventsP1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EventsP1.Models.EventsP1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventsP1.Models.EventsP1Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Events.AddOrUpdate(
                  p => p.Name,
                  new Event
                  {
                      Name = "Glasto",
                      Location = "WestBy",
                      Date = "25 June",
                      Allday = true,
                  },
                  new Event
                  {
                      Name = "Double Date",
                      Location = "WestBy",
                      Date = "24 June",
                      Allday = false,
                  },
                  new Event
                  {
                      Name = "Petes Coming Out Party",
                      Location = "WestBy",
                      Date = "26 June",
                      Allday = true,
                  }
                );
            
        }
    }
}
