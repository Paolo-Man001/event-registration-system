using EventRegistrationSystem.Models;
using System.Collections.Generic;

namespace EventRegistrationSystem.ViewModels
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}