namespace EventsP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        AtendeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Driver = c.Boolean(nullable: false),
                        Group_GroupID = c.Int(),
                        Event_EventID = c.Int(),
                    })
                .PrimaryKey(t => t.AtendeeID)
                .ForeignKey("dbo.Groups", t => t.Group_GroupID)
                .ForeignKey("dbo.Events", t => t.Event_EventID)
                .Index(t => t.Group_GroupID)
                .Index(t => t.Event_EventID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Admin_AtendeeID = c.Int(),
                        Attendee_AtendeeID = c.Int(),
                    })
                .PrimaryKey(t => t.GroupID)
                .ForeignKey("dbo.Attendees", t => t.Admin_AtendeeID)
                .ForeignKey("dbo.Attendees", t => t.Attendee_AtendeeID)
                .Index(t => t.Admin_AtendeeID)
                .Index(t => t.Attendee_AtendeeID);
            
            AddColumn("dbo.Events", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "DateFinish", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Date", c => c.String());
            DropForeignKey("dbo.Attendees", "Event_EventID", "dbo.Events");
            DropForeignKey("dbo.Groups", "Attendee_AtendeeID", "dbo.Attendees");
            DropForeignKey("dbo.Attendees", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Admin_AtendeeID", "dbo.Attendees");
            DropIndex("dbo.Groups", new[] { "Attendee_AtendeeID" });
            DropIndex("dbo.Groups", new[] { "Admin_AtendeeID" });
            DropIndex("dbo.Attendees", new[] { "Event_EventID" });
            DropIndex("dbo.Attendees", new[] { "Group_GroupID" });
            DropColumn("dbo.Events", "DateFinish");
            DropColumn("dbo.Events", "DateStart");
            DropTable("dbo.Groups");
            DropTable("dbo.Attendees");
        }
    }
}
