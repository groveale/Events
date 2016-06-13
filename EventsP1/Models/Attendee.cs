using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsP1.Models
{
    public class Attendee
    {
        [Key]
        public int AtendeeID { get; set; }
        public string Name { get; set; }
        public bool Driver { get; set; }
        public List<Group> Groups{ get; set; }

    }
}