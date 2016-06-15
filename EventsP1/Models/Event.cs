using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace EventsP1.Models
{
    public class Event
    {
        [Key]
        public int EventID{ get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        [DataType(DataType.Date)]
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
        [NotMapped]
        public SelectList AttendeeList { get; set; }


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

        public IEnumerable<Attendee> getAttendess()
        {
            IEnumerable<Attendee> friendsList;

            EventsP1Context db = new EventsP1Context();

            friendsList = db.Attendees.ToList();

            return friendsList;
        }

    }

}
