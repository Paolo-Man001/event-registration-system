namespace EventRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelPropAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Client", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Client", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Client", "Phone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Event", "EventName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Event", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Event", "Location", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Event", "Description", c => c.String());
            AlterColumn("dbo.Event", "EventName", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "FullName", c => c.String(nullable: false));
        }
    }
}
