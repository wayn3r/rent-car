using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{
    public class Cars
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo No. Chasis es obligatorio.")]
        [Display(Name = "No. Chasis")]
        public string NoChasis { get; set; }

        [Required(ErrorMessage = "El campo No. Motor es obligatorio.")]
        [Display(Name = "No. Motor")]
        public string NoMotor { get; set; }

        [Required(ErrorMessage = "El campo No. Placa es obligatorio.")]
        [Display(Name = "No. Placa")]
        public string NoPlaca { get; set; }

        [Required(ErrorMessage = "El campo Tipo Vehiculo es obligatorio.")]
        [Display(Name = "Tipo de Vehiculo")]
        public int TipoVehiculoId { get; set; }

        [Required(ErrorMessage = "El campo Marca es obligatorio.")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "El campo Modelo es obligatorio.")]
        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "El campo Tipo de combustible es obligatorio.")]
        [Display(Name = "Tipo de combustible")]
        public int TipoCombustibleId { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}
