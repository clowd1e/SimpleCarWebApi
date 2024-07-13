using System.ComponentModel.DataAnnotations;

namespace SimpleCarWebApi.Models
{
    public class Car : BaseModel
    {
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required]
        public double TopSpeed { get; set; }

        [Required]
        public int CarBodyTypeId { get; set; }
        [Required]
        public CarBodyType CarBodyType { get; set; }
        [Required]
        public int CarBrandId { get; set; }
        [Required]
        public CarBrand CarBrand { get; set; }
    }
}
