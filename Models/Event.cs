using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventRegistrationSystem.Models
{
    public class Event
    {
        public int ID { get; set; }
        public int ClientID { get; set; }           // Foreign Key

        [Required(ErrorMessage = "Evnt Name is required.")]
        public string EventName { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Event Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Event Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Ticket Price is required.")]
        public decimal TicketPrice { get; set; }


        public virtual Client Client { get; set; }  // Foreign Key Reference Model
    }
}