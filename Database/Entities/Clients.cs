using RentCar.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{
    public class Clients
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        [CedulaValida(ErrorMessage = "El campo Cédula es invalido.")]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Tarjeta de Credito es obligatorio.")]
        [Display(Name = "Tarjeta de credito")]
        public string NoTarjetaCR { get; set; }

        [Required(ErrorMessage = "El campo Límite de Crédito es obligatorio.")]
        [Display(Name = "Limite de credito")]
        public decimal LimiteCredito { get; set; }

        [Required(ErrorMessage = "El campo Tipo Persona es obligatorio.")]
        [Display(Name = "Tipo de persona")]
        public string TipoPersona { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}
