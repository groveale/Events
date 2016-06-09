using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace EventsP1.Models
{
    public class Event
    {
        [Key]
        public int EventID{ get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public bool Allday { get; set; }
        public string Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
               "api/events/{0}", this.EventID);
            }
            set { }
        }
    }

}
