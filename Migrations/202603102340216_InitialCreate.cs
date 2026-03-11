namespace AppSenAgriculture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomCompletUtilisateur = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        AdresseUtilisateur = c.String(maxLength: 300, storeType: "nvarchar"),
                        EmailUtilisateur = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        TelUtilisateur = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        IdentifiantUtilisateur = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        MotDePasseUtilisateur = c.String(nullable: false, maxLength: 300, storeType: "nvarchar"),
                        ProfessionClient = c.String(unicode: false),
                        NineaCultivateur = c.String(maxLength: 20, storeType: "nvarchar"),
                        RccmCultivateur = c.String(maxLength: 30, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategorie = c.Int(nullable: false, identity: true),
                        LibelleCategorie = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        DescriptionCategorie = c.String(maxLength: 2000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdCategorie);
            
            CreateTable(
                "dbo.Champs",
                c => new
                    {
                        IdChamp = c.Int(nullable: false, identity: true),
                        LibelleChamp = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Superficie = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        IdCommune = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdChamp)
                .ForeignKey("dbo.Communes", t => t.IdCommune, cascadeDelete: true)
                .Index(t => t.IdCommune);
            
            CreateTable(
                "dbo.Communes",
                c => new
                    {
                        IdCommune = c.Int(nullable: false, identity: true),
                        LibelleCommune = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        CodeCommune = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        IdDepartement = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCommune)
                .ForeignKey("dbo.Departements", t => t.IdDepartement, cascadeDelete: true)
                .Index(t => t.IdDepartement);
            
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        IdDepartement = c.Int(nullable: false, identity: true),
                        CodeDepartement = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        LibelleDepartement = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        IdRegion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDepartement)
                .ForeignKey("dbo.Regions", t => t.IdRegion, cascadeDelete: true)
                .Index(t => t.IdRegion);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        IdRegion = c.Int(nullable: false, identity: true),
                        CodeRegion = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        LibelleRegion = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdRegion);
            
            CreateTable(
                "dbo.MoyenPaiements",
                c => new
                    {
                        IdMoyenPaiement = c.Int(nullable: false, identity: true),
                        CodeMoyenPaiement = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        LibelleMoyenPaiement = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdMoyenPaiement);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        IdProduit = c.Int(nullable: false, identity: true),
                        LibelleProduit = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        DescriptionProduit = c.String(nullable: false, maxLength: 5000, storeType: "nvarchar"),
                        PrixUnitaireMin = c.Double(nullable: false),
                        IdUniteMesure = c.Int(nullable: false),
                        PrixUnitaireMax = c.Double(nullable: false),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduit)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .ForeignKey("dbo.UniteMesures", t => t.IdUniteMesure, cascadeDelete: true)
                .Index(t => t.IdUniteMesure)
                .Index(t => t.CategorieId);
            
            CreateTable(
                "dbo.UniteMesures",
                c => new
                    {
                        IdUnite = c.Int(nullable: false, identity: true),
                        CodeUnite = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        LibelleUnite = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdUnite);
            
            CreateTable(
                "dbo.Td_Erreur",
                c => new
                    {
                        IdErreur = c.Int(nullable: false, identity: true),
                        TitreErreur = c.String(maxLength: 200, storeType: "nvarchar"),
                        DescriptionErreur = c.String(maxLength: 2000, storeType: "nvarchar"),
                        DateErreur = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.IdErreur);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "IdUniteMesure", "dbo.UniteMesures");
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.Champs", "IdCommune", "dbo.Communes");
            DropForeignKey("dbo.Communes", "IdDepartement", "dbo.Departements");
            DropForeignKey("dbo.Departements", "IdRegion", "dbo.Regions");
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            DropIndex("dbo.Produits", new[] { "IdUniteMesure" });
            DropIndex("dbo.Departements", new[] { "IdRegion" });
            DropIndex("dbo.Communes", new[] { "IdDepartement" });
            DropIndex("dbo.Champs", new[] { "IdCommune" });
            DropTable("dbo.Td_Erreur");
            DropTable("dbo.UniteMesures");
            DropTable("dbo.Produits");
            DropTable("dbo.MoyenPaiements");
            DropTable("dbo.Regions");
            DropTable("dbo.Departements");
            DropTable("dbo.Communes");
            DropTable("dbo.Champs");
            DropTable("dbo.Categories");
            DropTable("dbo.Utilisateurs");
        }
    }
}
