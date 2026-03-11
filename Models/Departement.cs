using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    public class Departement
    {
        [Key]
        public int IdDepartement { get; set; }  // Clé primaire

        [Required, MaxLength(20)]
        public string CodeDepartement { get; set; }

        [Required, MaxLength(100)]
        public string LibelleDepartement { get; set; }

        public int IdRegion { get; set; }

        [ForeignKey("IdRegion")] // Spécifie que IdRegion est une clé étrangère
        public virtual Region Region { get; set; }  // Propriété de navigation vers la classe Region
    }
}
