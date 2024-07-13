using Microsoft.EntityFrameworkCore;
using SimpleCarWebApi.Models;

namespace SimpleCarWebApi.Data
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarBodyType> CarBodyTypes { get; set; }

        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }
    }
}
