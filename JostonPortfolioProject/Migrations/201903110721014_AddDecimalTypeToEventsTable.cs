namespace JostonPortfolioProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDecimalTypeToEventsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Price", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
