using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventRegistrationSystem.Models
{
    public class Event
    {
        public int ID { get; set; }
        public int ClientID { get; set; }           // Foreign Key


        [Required(ErrorMessage = "Event Name is required.")]
        [Column(TypeName = "varchar(100)")]
        public string EventName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Event Location is required.")]
        [Column(TypeName = "varchar(100)")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Event Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Ticket Price is required.")]
        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }


        public virtual Client Client { get; set; }  // Foreign Key Reference Model
    }
}