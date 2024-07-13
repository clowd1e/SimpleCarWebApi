using System.ComponentModel.DataAnnotations;

namespace SimpleCarWebApi.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
