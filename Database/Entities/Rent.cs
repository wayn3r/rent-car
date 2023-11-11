using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Database.Entities
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "No. de Renta")]
        public string NoRenta { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        [Display(Name = "Empleado")]
        public virtual Employee? empleado { get; set; }

        [Required]
        [Display(Name = "Vehiculo")]
        public int VehículoId { get; set; }

        [ForeignKey("VehículoId")]
        [Display(Name = "Vehiculo")]
        public virtual Cars? vehiculo { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int ClienteId {  get; set; }

        [ForeignKey("ClienteId")]
        [Display(Name = "Cliente")]
        public virtual Clients? cliente { get; set; }

        [Required]
        [Display(Name = "Fecha de Renta")]
        public DateTime FechaRenta { get; set; }

        [Required]
        [Display(Name = "Fecha de Devolucion")]
        public DateTime FechaDevolución {  get; set; }

        [Required]
        [Display(Name = "Monto por Dia")]
        public double MontoDia { get; set; }

        [Required]
        [Display(Name = "Cantidad de Dias")]
        public int CantidadDias {  get; set; }

        [Required]
        [Display(Name = "Comentario")]
        public string Comentario { get; set; }
        
        [Required]
        [Display(Name = "Estado")]
        public Status Estado {  get; set; }

        

    }
}
