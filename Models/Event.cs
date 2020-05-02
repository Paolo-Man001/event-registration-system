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
        [StringLength(100), MinLength(3), Display(Name = "Events"),]
        public string EventName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Event Location is required.")]
        [StringLength(100)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Event Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyy}",ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Ticket Price is required.")]
        [Display(Name = "Ticket Price"),Range(0, 100),DataType(DataType.Currency)]
        public decimal TicketPrice { get; set; }


        public virtual Client Client { get; set; }  // Foreign Key Reference Model
    }
}