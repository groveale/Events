﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventsP1.Models
{
    public class EventsP1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EventsP1Context() : base("name=EventsP1Context")
        {
        }


        public System.Data.Entity.DbSet<EventsP1.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<EventsP1.Models.CalendarEvent> CalendarEvents { get; set; }

        public System.Data.Entity.DbSet<EventsP1.Models.Attendee> Attendees { get; set; }

        public System.Data.Entity.DbSet<EventsP1.Models.Group> Groups { get; set; }
    }
}
