using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EventsP1.Models
{
    public class CalendarEvent
    {
        [Key]
        public int CalendarEventID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public bool Allday { get; set; }
        public bool OpenInvite { get; set; }
        public string Attendees { get; set; }

        public static List<CalendarEvent> LoadAllAppointmentsInDateRange(double start, double end)
        {
            //var fromDate = ConvertFromUnixTimestamp(start);
            //var toDate = ConvertFromUnixTimestamp(end);
            using (EventsP1Context ent = new EventsP1Context())
            {
                var rslt = ent.CalendarEvents;
                    //Where(s => s.DateStart >= fromDate && s.DateFinish <= toDate);

                List<CalendarEvent> result = new List<CalendarEvent>();

                foreach (var item in rslt)
               {
                    CalendarEvent rec = new CalendarEvent();
                    rec.CalendarEventID = item.CalendarEventID;
                    rec.Name = item.Name;
                    rec.DateStart = item.DateStart;
                    // "s" is a preset format that outputs as: "2009-02-27T12:12:22"
                    rec.DateFinish = item.DateFinish;
                    //rec.EndDateString = item.DateTimeScheduled.AddMinutes(item.AppointmentLength).ToString("s");
                    // field AppointmentLength is in minutes
                    rec.Allday = item.Allday;

                    result.Add(rec);
                }
                return result;
            }
        }


        public static void UpdateCalendarEvent(int id, string NewEventStart, string NewEventEnd)
        {
            // EventStart comes ISO 8601 format, eg:  "2000-01-10T10:00:00Z" - need to convert to DateTime
            using (EventsP1Context ent = new EventsP1Context())
            {
                var rec = ent.CalendarEvents.FirstOrDefault(s => s.CalendarEventID == id);
                if (rec != null)
                {
                    DateTime DateTimeStart = DateTime.Parse(NewEventStart, null, System.Globalization.DateTimeStyles.RoundtripKind).ToLocalTime(); // and convert offset to localtime
                    rec.DateStart = DateTimeStart;

                    DateTime DateTimeEnd = DateTime.Parse(NewEventEnd, null, System.Globalization.DateTimeStyles.RoundtripKind).ToLocalTime(); // and convert offset to localtime
                    rec.DateFinish = DateTimeEnd;

                    ent.SaveChanges();
                }
            }
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

    }


   

   

}