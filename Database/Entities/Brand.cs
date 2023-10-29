using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Database.Entities
{

    public class Brand
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [StringLength(50, ErrorMessage = "La descripcion debe ser menor a 50 caracteres")]
        [Display(Name = "Descripcion")]
        public string description { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public Status status { get; set; }


    }
}
