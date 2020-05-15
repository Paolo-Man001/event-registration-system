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
        public ActionResult Index(string clientSearchTerm)              //  'searchTerm' is String-value input from search-box.
        {
            var clients = db.Clients.OrderBy(c => c.FullName);          // Assign all Clients into the variable in alphabetical order by 'Full Name'

            if (!string.IsNullOrEmpty(clientSearchTerm))                // Checks the textbox if it's not empty
            {
                clients = clients
                    .Where(c => c.FullName.Contains(clientSearchTerm))  // iterate through Client Names
                    .OrderBy(c => c.FullName);                          // order Client Names alphabetically
            }

            return View(clients.ToList());                              // Convert 'clients' into 'List' data structure
        }


        // GET: Client Details
        public ActionResult Details(int? id)            // optional(nullable) argument indicated by '?'
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
        [HttpPost]                              // This tells the server this method responds to a 'POST' request
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FullName,Email,Address,Phone")] Client client)
        {
            if (ModelState.IsValid)             // Check if Model is valid. Validation is done in the server referencing Data Annotation
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
            if (id == null)                         // Http-Header Status Code 400 is sent to the Client if Id does not exist
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Status-Code 400
            }
            Client client = db.Clients.Find(id);    // query using the ClientID of the clicked-row(record) from View
            if (client == null)                     // If there is no Client(unlikely)
            {
                return HttpNotFound();
            }
            return View(client);                    // returns the Client that was clicked from the List
        }

        // POST: Client/Edit/{id}
        [HttpPost]                                  // This tells the server this method responds to a 'POST' request from the Edit View
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Email,Address, Phone")] Client client)
        {
            if (ModelState.IsValid)                 // Checks validity of the 'client' argument
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");

                ViewBag.isSubmitted = true;         // If ViewBag(boolean) used to show/hide pop-up notification.
            }
            return View(client);
        }


        // GET: Client/Delete
        public ActionResult Delete(int? id)         // gets the ClientID
        {
            if (id == null)                         // Check ClientID, if null then return StatusCode 400
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);    // Iterate client-table find record that match the 'id'
            if (client == null)                     // checks if client is null, if yes, return 'not found' class object
            {
                return HttpNotFound();
            }
            return View(client);                    // return the client found by 'id'
        }
        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]            // Specify this Action as SQLquery "DELETE"
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