namespace EventRegistrationSystem.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EventRegistrationSystem.DAL.EventRegistrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Bypassing this Seed(). Using DataInitializer() to create Database, then seed the client + events.
        protected override void Seed(EventRegistrationSystem.DAL.EventRegistrationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
