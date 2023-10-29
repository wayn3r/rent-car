using RentCar.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{
    public class Clients
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        [CedulaValida(ErrorMessage = "El campo Cédula es invalido.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo No. Tarjeta CR es obligatorio.")]
        public string NoTarjetaCR { get; set; }

        [Required(ErrorMessage = "El campo Límite de Crédito es obligatorio.")]
        public decimal LimiteCredito { get; set; }

        [Required(ErrorMessage = "El campo Tipo Persona es obligatorio.")]
        public string TipoPersona { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string Estado { get; set; }
    }
}
