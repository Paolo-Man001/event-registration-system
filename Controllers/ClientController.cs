using EventRegistrationSystem.DAL;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EventRegistrationSystem.ViewModels;

namespace EventRegistrationSystem.Controllers
{
    public class ClientController : Controller
    {
        private EventRegistrationContext db = new EventRegistrationContext();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new ClientDetailsViewModel();   // Create instance of ViewModel  of Client-Detail
            viewModel.Client = db.Clients.Find(id);         // Assign db.Client matching the 'id'
            viewModel.Events = db.Events                    // Assign db.Client's Event/s (if any)
                .Where(e => e.ClientID == id)
                .OrderBy(e => e.EventName)
                .ToList();

            return View(viewModel);

        }
    }
}