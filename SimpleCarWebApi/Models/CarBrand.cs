using System.ComponentModel.DataAnnotations;

namespace SimpleCarWebApi.Models
{
    public class CarBrand : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }

        public CarBrand() { }
        public CarBrand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
