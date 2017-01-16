namespace StockCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class objet2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ventes", "IdObjet", "dbo.Objets");
            DropIndex("dbo.Ventes", new[] { "IdObjet" });
            AlterColumn("dbo.Ventes", "IdObjet", c => c.Int());
            CreateIndex("dbo.Ventes", "IdObjet");
            AddForeignKey("dbo.Ventes", "IdObjet", "dbo.Objets", "IdObjet");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventes", "IdObjet", "dbo.Objets");
            DropIndex("dbo.Ventes", new[] { "IdObjet" });
            AlterColumn("dbo.Ventes", "IdObjet", c => c.Int(nullable: false));
            CreateIndex("dbo.Ventes", "IdObjet");
            AddForeignKey("dbo.Ventes", "IdObjet", "dbo.Objets", "IdObjet", cascadeDelete: true);
        }
    }
}
