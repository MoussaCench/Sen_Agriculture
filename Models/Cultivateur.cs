using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Cultivateur: Facilitateur  // Héritage de la classe Facilitateur
    {
        [Required,MaxLength(20)]
        public string NineaCultivateur {  get; set; }
        [Required,MaxLength(30)]
        public string RccmCultivateur { get; set; } // 
    }
}
