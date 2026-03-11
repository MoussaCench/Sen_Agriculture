using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    public class Champ // 
    {
        [Key] // Clé primaire
        public int IdChamp { get; set; }

        [Required, MaxLength(100)]
        public string LibelleChamp { get; set; }

        public double Superficie { get; set; }

       
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Clé étrangère vers Commune
        public int IdCommune { get; set; }

        [ForeignKey("IdCommune")] // Spécifie que IdCommune est une clé étrangère
        public virtual Commune Commune { get; set; } // Propriété de navigation vers la classe Commune
    }
}
