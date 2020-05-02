using EventRegistrationSystem.DAL;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EventRegistrationSystem.ViewModels;
using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Controllers
{
    public class ClientController : Controller
    {
        private EventRegistrationContext db = new EventRegistrationContext();

        // GET: Client List
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }


        // GET: Client Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new ClientDetailsViewModel();   // Create instance of ViewModel of Client-Detail
            viewModel.Client = db.Clients.Find(id);         // Assign db.Client matching the 'id'
            viewModel.Events = db.Events                    // Assign db.Client's Event/s (if any)
                .Where(e => e.ClientID == id)
                .OrderBy(e => e.EventName)
                .ToList();

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

    }
}