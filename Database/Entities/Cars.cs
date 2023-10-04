using System;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{
    public class Cars
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo No. Chasis es obligatorio.")]
        public string NoChasis { get; set; }

        [Required(ErrorMessage = "El campo No. Motor es obligatorio.")]
        public string NoMotor { get; set; }

        [Required(ErrorMessage = "El campo No. Placa es obligatorio.")]
        public string NoPlaca { get; set; }

        [Required(ErrorMessage = "El campo Tipo Vehiculo es obligatorio.")]
        public int TipoVehiculoId { get; set; }

        [Required(ErrorMessage = "El campo Marca es obligatorio.")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "El campo Modelo es obligatorio.")]
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "El campo Tipo Combustible es obligatorio.")]
        public int TipoCombustibleId { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string Estado { get; set; }
    }
}
