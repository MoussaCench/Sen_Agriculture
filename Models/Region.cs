using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class Region // Représente les régions du Sénégal
    {
        [Key]
        public int IdRegion { get; set; }

        // Code codifié par défaut : SNDKR
        [Required, MaxLength(20)]
        public string CodeRegion { get; set; } 

        [Required, MaxLength(100)]
        public string LibelleRegion { get; set; }

        public virtual ICollection<Departement> Departements { get; set; } // Propriété de navigation vers les départements de la région
    }
}
