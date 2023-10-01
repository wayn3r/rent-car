using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Database.Entities
{

    public class Brand
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripcion")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public Status status { get; set; }


    }
}
