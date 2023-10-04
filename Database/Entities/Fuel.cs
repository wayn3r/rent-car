using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Database.Entities
{



    public class Fuel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Descripcion")]

        public string description { get; set; }

        [Display(Name = "Estado")]
        public Status status { get; set; }


    }
}
