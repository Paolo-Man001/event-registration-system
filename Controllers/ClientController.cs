using EventRegistrationSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}