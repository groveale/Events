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
                  DateStart = new DateTime(2016, 6, 25, 11, 0, 0),
                  DateFinish = new DateTime(2016, 6, 25, 23, 0, 0),
                  Allday = false,
                  //invitedAttendees = "groveale, nickolarse",
                  },
            new Event
            {
                Name = "Double Date",
                Location = "WestBy",
                DateStart = new DateTime(2016, 6, 24, 11, 0, 0),
                DateFinish = new DateTime(2016, 6, 24, 23, 0, 0),
                Allday = false,
                //invitedAttendees = "groveale, slim",
            },
            new Event
            {
                Name = "Petes Coming Out Party",
                Location = "WestBy",
                DateStart = new DateTime(2016, 6, 26, 11, 0, 0),
                DateFinish = new DateTime(2016, 6, 26, 23, 0, 0),
                Allday = true,
                //invitedAttendees = { 1, 4 }
            }
                );

            context.Attendees.AddOrUpdate(
             p => p.AtendeeID,
             new Attendee
             {
                 AtendeeID = 1,
                 Name = "Slim",
                 Driver = true,
                 //Groups
              },
           new Attendee
           {
               AtendeeID = 2,
               Name = "Grosser",
               Driver = false,
               //Groups = 
               
            },
           new Attendee
           {
               AtendeeID = 3,
               Name = "Nicolarse",
               Driver = true,
               //Groups = 
           },
           new Attendee
           {
               AtendeeID = 4,
               Name = "Pete",
               Driver = false,
               //Groups = 
           }
               );

        }
    }
}
