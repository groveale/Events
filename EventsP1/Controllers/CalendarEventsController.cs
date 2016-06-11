using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventsP1.Models;

namespace EventsP1.Controllers
{
    public class CalendarEventsController : Controller
    {
        private EventsP1Context db = new EventsP1Context();

        // GET: CalendarEvents
        public ActionResult Index()
        {
            var evetns = (db.CalendarEvents.ToList());
            return View(evetns);
        }

        // GET: CalendarEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = db.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarEvent);
        }

        // GET: CalendarEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalendarEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalendarEventID,Name,Location,DateStart,DateFinish,Allday,OpenInvite,Attendees")] CalendarEvent calendarEvent)
        {
            if (ModelState.IsValid)
            {
                db.CalendarEvents.Add(calendarEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calendarEvent);
        }

        // GET: CalendarEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = db.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarEvent);
        }

        // POST: CalendarEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalendarEventID,Name,Location,DateStart,DateFinish,Allday,OpenInvite,Attendees")] CalendarEvent calendarEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendarEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calendarEvent);
        }

        // GET: CalendarEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = db.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarEvent);
        }

        // POST: CalendarEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalendarEvent calendarEvent = db.CalendarEvents.Find(id);
            db.CalendarEvents.Remove(calendarEvent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void UpdateEvent(int id, string NewEventStart, string NewEventEnd)
        {
            CalendarEvent.UpdateCalendarEvent(id, NewEventStart, NewEventEnd);
        }



        public JsonResult GetCalendarEvents()
        {
            //double start, double end
            //var ApptListForDate = CalendarEvent.LoadAllAppointmentsInDateRange(start, end);
            var ApptListForDate = db.CalendarEvents;
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.CalendarEventID,
                                title = e.Name,
                                start = e.DateStart,
                                end = e.DateFinish,
                                allDay = e.Allday,

                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
