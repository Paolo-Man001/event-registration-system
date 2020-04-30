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
        [Column(TypeName = "varchar(100)")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }
}