using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Magic_BismarkAramayo.Models
{
    public class Futuro
    {
        [Key]
        public string FuturoId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Es requerido")]
        public string Vision { get; set; }
        [Url]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La longitud debe ser entre {2} y {1}")]
        public string Imagen { get; set; }
    }
}