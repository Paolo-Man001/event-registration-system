using EventRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EventRegistrationSystem.DAL
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<EventRegistrationContext>
    {
        protected override void Seed(EventRegistrationContext context)
        {
            var clients = new List<Client>
            {
                new Client
                {
                    FullName="Elwood Quin",
                    Email="equin0@businessweek.com",
                    Address="33821 Mitchell Circle",
                    Phone= "129-626-7937"
                },
                new Client
                {
                    FullName="Cherrita Sherrell",
                    Email="csherrell1@tripod.com",
                    Address="9676 Darwin Terrace",
                    Phone="289-409-5663"
                },
                new Client
                {
                    FullName="Jackie O'Hallihane",
                    Email="johallihane2@nasa.gov",
                    Address="5710 Miller Terrace",
                    Phone="228-232-6368"
                },
                new Client
                {
                    FullName="Sophia Arthars",
                    Email="sarthars3@ovh.net",
                    Address="6 Fremont Parkway",
                    Phone="112-696-7214"
                },
                new Client
                {
                    FullName="Ella Trevear",
                    Email="etrevear4@msn.com",
                    Address="70 Monica Lane",
                    Phone="806-956-6231"
                }
            };
            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();

            var events = new List<Event>
            {
                // Client 1
                new Event
                {
                    ClientID=1,
                    EventName="Granular Deliverables",
                    Description="Synergized executive hierarchy",
                    Location="Lanling, Indonesia",
                    Date=DateTime.Parse("2020-08-10"),
                    TicketPrice=12.79M
                },
                new Event
                {
                    ClientID=1,
                    EventName="Streamline synergistic networks",
                    Description="How to Assimilated high-level success",
                    Location="Pasar, Turkey",
                    Date=DateTime.Parse("2021-06-02"),
                    TicketPrice=17.14M
                },
                // Client 2
                new Event
                {
                    ClientID=2,
                    EventName="Cross-platform Niches",
                    Description="Balanced regional system engine",
                    Location="Oubei, Japan",
                    Date=DateTime.Parse("2021-09-14"),
                    TicketPrice=14.84M
                },
                // Client 3
                new Event
                {
                    ClientID=3,
                    EventName="Engage real-time partnerships",
                    Description="Persevering human-resource product",
                    Location="Fontenay-sous-Bois, France",
                    Date=DateTime.Parse("2021-10-10"),
                    TicketPrice=12.48M
                },
                // Client 4
                new Event
                {
                    ClientID=4,
                    EventName="EF6 Conference",
                    Description="Enterprise-wide global website",
                    Location="Sungaikupang, Vietnam",
                    Date=DateTime.Parse("2020-07-08"),
                    TicketPrice=13.99M
                },
                // Client 5
                new Event
                {
                    ClientID=5,
                    EventName="enterprise infrastructures party",
                    Description="Monitored actuating open system",
                    Location="Monte da Pedra, Italia",
                    Date=DateTime.Parse("2021-01-21"),
                    TicketPrice=15.27M
                },
                new Event
                {
                    ClientID=5,
                    EventName="Cross-media meet & greet",
                    Description="Object-based zero tolerance groupware",
                    Location="Чучер - Сандево, Russia",
                    Date=DateTime.Parse("2021-09-09"),
                    TicketPrice=15.40M
                },
                new Event
                {
                    ClientID=5,
                    EventName="Rave Portals Awards",
                    Description="Virtual Awards Show in Cyberspace",
                    Location="Raffingora, Namibya",
                    Date=DateTime.Parse("2020-08-07"),
                    TicketPrice=16.64M
                }
            };
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}