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
            context.CalendarEvents.AddOrUpdate(
              p => p.Name,
              new CalendarEvent
              {
                  Name = "Glasto",
                  Location = "WestBy",
                  DateStart = new DateTime(2016, 6, 25, 11, 0, 0),
                  DateFinish = new DateTime(2016, 6, 25, 23, 0, 0),
                  Allday = false,
                  OpenInvite = true,
                  Attendees = "groveale, nickolarse",
                  },
                  new CalendarEvent
                  {
                      Name = "Double Date",
                      Location = "WestBy",
                      DateStart = new DateTime(2016, 6, 24, 11, 0, 0),
                      DateFinish = new DateTime(2016, 6, 24, 23, 0, 0),
                      Allday = false,
                      OpenInvite = false,
                      Attendees = "groveale, slim",
                  },
                  new CalendarEvent
                  {
                      Name = "Petes Coming Out Party",
                      Location = "WestBy",
                      DateStart = new DateTime(2016, 6, 26, 11, 0, 0),
                      DateFinish = new DateTime(2016, 6, 26, 23, 0, 0),
                      Allday = true,
                      OpenInvite = true,
                      Attendees = "groveale, boysons",
                  }
                );
            
        }
    }
}
