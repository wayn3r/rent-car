using RentCar.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{
    public class Inspections
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Kilometraje { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required]
        [StringLength(50)]
        public string Resultado { get; set; }

        [StringLength(250)]
        public string Observaciones { get; set; }
    }
}
