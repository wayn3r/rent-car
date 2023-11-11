using RentCar.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        [CedulaValida(ErrorMessage = "El campo Cédula es invalido.")]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Tanda es obligatorio.")]
        [Display(Name = "Tanda")]
        public string Tanda { get; set; }

        [Required(ErrorMessage = "El campo porcentaje de comision es obligatorio.")]
        [Display(Name = "Porcentaje de Comision")]
        public decimal Porcentajecomision { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Persona es obligatorio.")]
        [Display(Name = "Fecha de Ingreso")]
        public string Fechaingreso { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}
