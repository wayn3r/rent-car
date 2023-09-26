using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Database.Entities
{

    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string description { get; set; }

        public Status status { get; set; }

        public int brandId { get; set; }

        [ForeignKey("brandId")]
        public virtual Brand brand { get; set; }
    }
}
