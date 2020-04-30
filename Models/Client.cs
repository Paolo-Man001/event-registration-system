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

        [Required]
        public string FullName { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Phone { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }
}