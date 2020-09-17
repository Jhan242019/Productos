using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Models
{
    public class Producto
    {
        [Required(ErrorMessage = "El campo id es obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo categoria es obligatorio")]
        public int Categoria { get; set; }
        [Required(ErrorMessage = "El campo proveedor es obligatorio")]
        public string Proveedor { get; set; }
        [Required(ErrorMessage = "El campo Costo es obligatorio")]
        public decimal Costo { get; set; }
        
    }
}
