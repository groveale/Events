using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsP1.Models
{
    public class Group
    {

        [Key]
        public int GroupID { get; set; }
        public string Name { get; set; }
        public Attendee Admin { get; set; }
        public List<Attendee> Members { get; set; }

    }
}