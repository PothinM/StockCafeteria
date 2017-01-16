namespace StockCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generation3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Commandes", "dateCommande", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Commandes", "dateCommande");
        }
    }
}
