using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models
{
    public class Client
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Client Name")]
        [StringLength(100), MinLength(3)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(50), MinLength(6)]
        public string Phone { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }
}