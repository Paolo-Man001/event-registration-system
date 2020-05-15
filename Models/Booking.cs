using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int EventID { get; set; }           // Foreign Key
       

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Customer Name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be at 2 to 100 characters.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer Email is required.")]
        [EmailAddress, Display(Name = "Customer Email")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Email must be 6 to 100 characters.")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Customer Phone Number is required.")]
        [Display(Name = "Customer Phone")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Phone number must be 6 to 50 Characters.")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "1 ticket per person is required for this event.")]
        [Display(Name = "Ticket Count")]
        public int TicketCount { get; set; }

        [Display(Name = "Total Price"), DataType(DataType.Currency)]
        public decimal TotalPurchase { get; set; }


        public virtual Event Event { get; set; }    // Reference-Model for FK

    }
}