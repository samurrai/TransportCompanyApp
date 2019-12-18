namespace TransportCompanyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Delieveries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Weight = c.Int(nullable: false),
                        CityFrom = c.String(),
                        CityTo = c.String(),
                        DelieveryType = c.Int(nullable: false),
                        FinalSum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Delieveries");
        }
    }
}
