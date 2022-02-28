using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdetoFood.data.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Display(Name ="tipo de comida")]
        public tipoCocina Cocina { get; set; }
    }
}
