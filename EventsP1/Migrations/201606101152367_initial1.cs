namespace EventsP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        CalendarEventID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateFinish = c.DateTime(nullable: false),
                        Allday = c.Boolean(nullable: false),
                        OpenInvite = c.Boolean(nullable: false),
                        Attendees = c.String(),
                    })
                .PrimaryKey(t => t.CalendarEventID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalendarEvents");
        }
    }
}
