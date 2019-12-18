namespace TransportCompanyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Delieveries", "Recipient_Id", c => c.Guid());
            AddColumn("dbo.Delieveries", "Sender_Id", c => c.Guid());
            CreateIndex("dbo.Delieveries", "Recipient_Id");
            CreateIndex("dbo.Delieveries", "Sender_Id");
            AddForeignKey("dbo.Delieveries", "Recipient_Id", "dbo.Recipients", "Id");
            AddForeignKey("dbo.Delieveries", "Sender_Id", "dbo.Senders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Delieveries", "Sender_Id", "dbo.Senders");
            DropForeignKey("dbo.Delieveries", "Recipient_Id", "dbo.Recipients");
            DropIndex("dbo.Delieveries", new[] { "Sender_Id" });
            DropIndex("dbo.Delieveries", new[] { "Recipient_Id" });
            DropColumn("dbo.Delieveries", "Sender_Id");
            DropColumn("dbo.Delieveries", "Recipient_Id");
            DropTable("dbo.Senders");
            DropTable("dbo.Recipients");
        }
    }
}
