using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventRegistrationSystem.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        public string Phone { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }
}