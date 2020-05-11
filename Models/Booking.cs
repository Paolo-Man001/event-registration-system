using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventRegistrationSystem.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int EventID { get; set; }           // Foreign Key

    }
}