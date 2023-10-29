using RentCar.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        [CedulaValida(ErrorMessage = "El campo Cédula es invalido.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Tanda es obligatorio.")]
        public string Tanda { get; set; }

        [Required(ErrorMessage = "El campo porcentaje de comision es obligatorio.")]
        public decimal Porcentajecomision { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Persona es obligatorio.")]
        public string Fechaingreso { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string Estado { get; set; }
    }
}
