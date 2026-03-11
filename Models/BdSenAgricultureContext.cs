using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace AppSenAgriculture.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdSenAgricultureContext : DbContext
    {
        public BdSenAgricultureContext() : base("conSenAgriculture")
        {
            // Ne supprime plus la base automatiquement
            Database.SetInitializer<BdSenAgricultureContext>(null);
        }

        public DbSet<Categorie> categories { get; set; }
        public DbSet<Produit> produits { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }
        public DbSet<Cultivateur> cultivateurs { get; set; }
        public DbSet<UniteMesure> unitemesures { get; set; }
        public DbSet<Facilitateur> facilitateurs { get; set; }

        public DbSet<Region> regions { get; set; }
        public DbSet<Departement> departements { get; set; }
        public DbSet<Commune> communes { get; set; }
        public DbSet<Champ> champs { get; set; }

        public DbSet<Admin> admins { get; set; }

        public DbSet<Td_Erreur> td_Erreurs { get; set; }
        public DbSet<MoyenPaiement> moyenpaiements { get; set; }
    }
}
