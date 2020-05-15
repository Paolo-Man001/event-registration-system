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
        public ActionResult Index(string clientSearchTerm)              // 'searchTerm' is String-value input from search-box, pass as arg
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
        public ActionResult Details(int? id)            // Get the details of Client by passing ClientID arg
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
        [HttpPost]                              // This tells the server this method responds to a 'POST' request from CreateView
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


        // GET: Client/Delete/{id}
        public ActionResult Delete(int? id)         // gets the ClientID that is chosen to be deleted, and displays the client-detail
        {
            if (id == null)                         // Check ClientID, if null, then return StatusCode 400
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
        // POST: Client/Delete/{id}
        [HttpPost, ActionName("Delete")]            // Specify to Call this method, for the the submit(POST) in "Delete" Action.
        [ValidateAntiForgeryToken]                  
        public ActionResult DeleteConfirmed(int id) // Delete button is clicked, passing 'ClientID' as argument.
        {
            Client client = db.Clients.Find(id);    // Find the matching Id in Client-table.
            db.Clients.Remove(client);              // When ClientID is found , Remove from Client-table
            db.SaveChanges();                       // Save the changes in the Client-table
            return RedirectToAction("Index");       // Redirect the Page back to 'Index' View of Client
        }


        // This method disposes any unused excess-referencess to resources in the stack/heap that the garbage-collection missed.
        // This helps to avoid accidental memory leak and unnecessary background process that my cause the app to slow-down or crash.
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