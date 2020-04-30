﻿using EventRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EventRegistrationSystem.DAL
{
    public class EventRegistrationContext : DbContext
    {
        public EventRegistrationContext() : base("EventRegistrationContext") { }


        public DbSet<Client> Clients { get; set; }
        public DbSet<Event> Events { get; set; }


        // Prevent Plural-forms of table names:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}