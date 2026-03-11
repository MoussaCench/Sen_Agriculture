using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Utilisateur  // Classe de base pour les utilisateurs de l'application (clients, facilitateurs, etc.)
    {
        [Key] // Indique que la propriété ID est la clé primaire de la table
        public int ID { get; set; }  // Clé primaire auto-incrémentée
        [Required ,MaxLength(100)]
        public string NomCompletUtilisateur { get; set; }
        [MaxLength(300)]
        public string AdresseUtilisateur { get;set; }
        [Required,MaxLength(80)]
        public string EmailUtilisateur { get; set; }
        [Required, MaxLength(20)]
        public string TelUtilisateur { get; set; }
        [Required, MaxLength(20)]
        public string IdentifiantUtilisateur { get; set; }
        [Required, MaxLength(300)]
        public string MotDePasseUtilisateur { get; set; }

    }
}
