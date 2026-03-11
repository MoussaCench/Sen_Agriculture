using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    public class Commune
    {
        [Key] // Clé primaire
        public int IdCommune { get; set; }

        [Required, MaxLength(100)]
        public string LibelleCommune { get; set; }

        // Code codifié unique de la commune
        [Required, MaxLength(20)]
        public string CodeCommune { get; set; }

        // Clé étrangère vers Département
        public int IdDepartement { get; set; }

        [ForeignKey("IdDepartement")]
        public virtual Departement Departement { get; set; }
    }
}
