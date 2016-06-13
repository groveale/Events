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
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public bool Allday { get; set; }
        // Must be able to be populated by adding a Group of Attendess
        public List<Attendee> invitedAttendees { get; set; }
        public string Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
               "api/events/{0}", this.EventID);
            }
            set { }
        }


        // Function to invite attendess to event
        public List<Attendee> inviteAttendees(List<Attendee> attendeesToInvite)
        {

            foreach(var attendeeToInvite in attendeesToInvite)
            {
                invitedAttendees.Add(attendeeToInvite);
            }

            return invitedAttendees;
        }

        // Function to invite groups to event
        public void inviteGroups(List<Group> groupsToInvite)
        {
            foreach(var groupToInvite in groupsToInvite)
            {
                List<Attendee> membersOfGroup = groupToInvite.Members;
                //invite members
                inviteAttendees(membersOfGroup);
            }

        }

    }

}
