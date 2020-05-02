using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventRegistrationSystem.Models
{
    public class Client
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Client Name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be at 2 to 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Email must be 6 to 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Address must be 3 to 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Phone number must be 6 to 50 Characters.")]
        public string Phone { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }
}