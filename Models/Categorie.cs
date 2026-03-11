using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Categorie // Classe représentant une catégorie de produit dans l'application d'agriculture
    {
        [Key]
        public int IdCategorie { get; set; }
        [Required,MaxLength(100)]
        public string LibelleCategorie { get; set; }
        [MaxLength(2000)]
        public string DescriptionCategorie { get; set; }
    }
}
