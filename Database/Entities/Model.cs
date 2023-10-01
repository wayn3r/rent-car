using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Database.Entities
{

    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public Status status { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int brandId { get; set; }

        [ForeignKey("brandId")]
        [Display(Name = "Marca")]
        public virtual Brand? brand { get; set; }
    }
}
