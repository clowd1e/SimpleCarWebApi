using System.ComponentModel.DataAnnotations;

namespace SimpleCarWebApi.Models
{
    public class CarBodyType : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }

        public CarBodyType() { }
        public CarBodyType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
