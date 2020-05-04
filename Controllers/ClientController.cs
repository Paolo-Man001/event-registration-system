using EventRegistrationSystem.DAL;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EventRegistrationSystem.ViewModels;
using EventRegistrationSystem.Models;
using System.Data.Entity;

namespace EventRegistrationSystem.Controllers
{
    public class ClientController : Controller
    {
        private EventRegistrationContext db = new EventRegistrationContext();

        // GET: Client List
        public ActionResult Index()
        {
            return View(db.Clients.OrderBy(c => c.FullName).ToList());
        }


        // GET: Client Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new ClientDetailsViewModel  // Create instance of ViewModel of Client-Detail
            {
                Client = db.Clients.Find(id),           // Assign db.Client matching the 'id'
                Events = db.Events                      // Assign db.Client's Event/s (if any)
                .Where(e => e.ClientID == id)
                .OrderBy(e => e.EventName)
                .ToList()
            };

            return View(viewModel);
        }


        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create (new Client)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FullName,Email,Address,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }


        // GET: Client/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Email,Address, Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                ViewBag.isSubmitted = true;

                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(client);
        }


        // GET: Client/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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