using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models
{
    public class Event
    {
        public int ID { get; set; }
        public int ClientID { get; set; }           // Foreign Key


        [Required(ErrorMessage = "Event Name is required.")]
        [Display(Name = "Events")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Event Name must be 2 to 100 characters.")]
        public string EventName { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Event Description must be 2 to 100 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Event Location is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Location must be 2 to 50 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Event Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Ticket Price is required.")]
        [Display(Name = "Ticket Price"), Range(0, 100), DataType(DataType.Currency)]
        public decimal TicketPrice { get; set; }


        public virtual Client Client { get; set; }  // Foreign Key Reference Model
    }
}