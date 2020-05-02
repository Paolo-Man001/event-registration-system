using EventRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventRegistrationSystem.ViewModels
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}