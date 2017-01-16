namespace StockCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class objet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Objets", "IdCommande", "dbo.Commandes");
            DropIndex("dbo.Objets", new[] { "IdCommande" });
            AlterColumn("dbo.Objets", "IdCommande", c => c.Int());
            CreateIndex("dbo.Objets", "IdCommande");
            AddForeignKey("dbo.Objets", "IdCommande", "dbo.Commandes", "IdCommande");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objets", "IdCommande", "dbo.Commandes");
            DropIndex("dbo.Objets", new[] { "IdCommande" });
            AlterColumn("dbo.Objets", "IdCommande", c => c.Int(nullable: false));
            CreateIndex("dbo.Objets", "IdCommande");
            AddForeignKey("dbo.Objets", "IdCommande", "dbo.Commandes", "IdCommande", cascadeDelete: true);
        }
    }
}
