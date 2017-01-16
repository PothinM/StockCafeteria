namespace StockCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generation2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fournisseurs", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Fournisseurs", "Adresse", c => c.String(maxLength: 50));
            AlterColumn("dbo.TypeObjets", "Libelle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comptes", "Password", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comptes", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.TypeObjets", "Libelle", c => c.String(nullable: false));
            AlterColumn("dbo.Fournisseurs", "Adresse", c => c.String());
            AlterColumn("dbo.Fournisseurs", "Nom", c => c.String(nullable: false));
        }
    }
}
