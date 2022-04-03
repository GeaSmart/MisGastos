using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MisGastos.Models
{
    public class Gasto
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(70)")]
        [MaxLength(70)]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "El monto es obligatorio")]
        [DisplayName("Monto")]        
        public decimal Monto { get; set; }

        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "Ingrese la fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha del gasto")]        
        public DateTime Fecha { get; set; }
    }
}
