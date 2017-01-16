namespace StockCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profitDate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Profits");
            AddColumn("dbo.Profits", "IdProfit", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Profits", "DateDebut", c => c.DateTime(nullable: false));
            AddColumn("dbo.Profits", "DateFin", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Profits", "IdProfit");
            DropColumn("dbo.Profits", "DateSemaine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profits", "DateSemaine", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.Profits");
            DropColumn("dbo.Profits", "DateFin");
            DropColumn("dbo.Profits", "DateDebut");
            DropColumn("dbo.Profits", "IdProfit");
            AddPrimaryKey("dbo.Profits", "DateSemaine");
        }
    }
}
