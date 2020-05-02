using EventRegistrationSystem.DAL;
using EventRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Details(int? id)
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
    }
}