namespace StockCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class objet3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objets", "EstVendu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Objets", "EstVendu");
        }
    }
}
