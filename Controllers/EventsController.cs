using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EventRegistrationSystem.DAL;
using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Controllers
{
    public class EventsController : Controller
    {
        private EventRegistrationContext db = new EventRegistrationContext();

        // GET: Events
        public ActionResult Index(string eventSearchTerm)
        {
            var events = db.Events.Include(e => e.Client).OrderBy(e => e.EventName);

            if (!string.IsNullOrEmpty(eventSearchTerm))
            {
                events = events
                    .Where(e => e.EventName.Contains(eventSearchTerm))
                    .Include(e => e.Client)
                    .OrderBy(e => e.EventName);
            }
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FullName");
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClientID,EventName,Description,Location,Date,TicketPrice")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FullName", @event.ClientID);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FullName", @event.ClientID);
            return View(@event);
        }

        // POST: Events/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClientID,EventName,Description,Location,Date,TicketPrice")] Event @event)
        {
            if (ModelState.IsValid)
            {
                ViewBag.isSubmitted = true;

                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FullName", @event.ClientID);
            return View(@event);
        }

        // GET: Events/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
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
