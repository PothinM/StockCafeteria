namespace StockCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generation1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        IdCommande = c.Int(nullable: false, identity: true),
                        SommeCommande = c.Single(nullable: false),
                        IdFournisseur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCommande)
                .ForeignKey("dbo.Fournisseurs", t => t.IdFournisseur, cascadeDelete: true)
                .Index(t => t.IdFournisseur);
            
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        IdFournisseur = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.IdFournisseur);
            
            CreateTable(
                "dbo.Objets",
                c => new
                    {
                        IdObjet = c.Int(nullable: false, identity: true),
                        IdCommande = c.Int(nullable: false),
                        IdTypeObjet = c.Int(),
                    })
                .PrimaryKey(t => t.IdObjet)
                .ForeignKey("dbo.TypeObjets", t => t.IdTypeObjet)
                .ForeignKey("dbo.Commandes", t => t.IdCommande, cascadeDelete: true)
                .Index(t => t.IdCommande)
                .Index(t => t.IdTypeObjet);
            
            CreateTable(
                "dbo.TypeObjets",
                c => new
                    {
                        IdTO = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                        PrixVente = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdTO);
            
            CreateTable(
                "dbo.Comptes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profits",
                c => new
                    {
                        DateSemaine = c.DateTime(nullable: false),
                        Depense = c.Single(nullable: false),
                        Vente = c.Single(nullable: false),
                        Benefice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DateSemaine);
            
            CreateTable(
                "dbo.Ventes",
                c => new
                    {
                        IdVente = c.Int(nullable: false, identity: true),
                        DateVente = c.DateTime(nullable: false),
                        IdObjet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVente)
                .ForeignKey("dbo.Objets", t => t.IdObjet, cascadeDelete: true)
                .Index(t => t.IdObjet);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventes", "IdObjet", "dbo.Objets");
            DropForeignKey("dbo.Objets", "IdCommande", "dbo.Commandes");
            DropForeignKey("dbo.Objets", "IdTypeObjet", "dbo.TypeObjets");
            DropForeignKey("dbo.Commandes", "IdFournisseur", "dbo.Fournisseurs");
            DropIndex("dbo.Ventes", new[] { "IdObjet" });
            DropIndex("dbo.Objets", new[] { "IdTypeObjet" });
            DropIndex("dbo.Objets", new[] { "IdCommande" });
            DropIndex("dbo.Commandes", new[] { "IdFournisseur" });
            DropTable("dbo.Ventes");
            DropTable("dbo.Profits");
            DropTable("dbo.Comptes");
            DropTable("dbo.TypeObjets");
            DropTable("dbo.Objets");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.Commandes");
        }
    }
}
