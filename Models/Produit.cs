using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    public class Produit  // Représente les produits agricoles proposés sur la plateforme
    {
        [Key]
        public int IdProduit { get; set; }
        [MaxLength(100),Required]
        public string LibelleProduit { get; set; }
        [MaxLength(5000),Required]
        public string DescriptionProduit { get; set; }
        public double PrixUnitaireMin {  get; set; }
        public int IdUniteMesure { get; set; }
        [ForeignKey("IdUniteMesure")]
        public virtual UniteMesure UniteMesure{ get; set; }

        public double PrixUnitaireMax { get; set; }
        public int CategorieId {  get; set; }
        [ForeignKey ("CategorieId")]
        public virtual Categorie Categorie { get; set; }  // Propriété de navigation vers la classe Categorie
    }
}
