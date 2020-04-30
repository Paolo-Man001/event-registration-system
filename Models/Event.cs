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
        public int ClientID { get; set; }

        [Required]
        public string EventName { get; set; }

        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal TicketPrize { get; set; }


        public virtual Client Client { get; set; }
    }
}