using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class MoyenPaiement // Représente les moyens de paiement disponibles
    {
        [Key]
        public int IdMoyenPaiement { get; set; }

        [Required, MaxLength(20)]
        public string CodeMoyenPaiement { get; set; }

        [Required, MaxLength(100)]
        public string LibelleMoyenPaiement { get; set; }
    }
}
