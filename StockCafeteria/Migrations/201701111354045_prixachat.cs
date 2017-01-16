namespace StockCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prixachat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeObjets", "PrixAchat", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeObjets", "PrixAchat");
        }
    }
}
