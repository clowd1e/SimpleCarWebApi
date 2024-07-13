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

        public Car() { }
        public Car(int id, string model, int year, decimal price, string description, double topSpeed, int carBodyType, int carBrandId)
        {
            Id = id;
            Model = model;
            Year = year;
            Price = price;
            Description = description;
            TopSpeed = topSpeed;
            CarBodyTypeId = carBodyType;
            CarBrandId = carBrandId;
        }
    }
}
