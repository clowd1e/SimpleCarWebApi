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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var carBrands = new List<CarBrand>()
            {
                new CarBrand(1, "Audi"),
                new CarBrand(2, "Alfa Romeo"),
                new CarBrand(3, "Dodge"),
                new CarBrand(4, "BMW"),
                new CarBrand(5, "Hyundai"),
                new CarBrand(6, "Nissan")
            };

            var carBodyTypes = new List<CarBodyType>()
            {
                new CarBodyType(1, "SUV"),
                new CarBodyType(2, "Sedan"),
                new CarBodyType(3, "Convertible"),
                new CarBodyType(4, "Coupe")
            };

            var cars = new List<Car>() {
                new Car(1,
                        "Audi Q3 1.4 TFSI",
                        2019,
                        36.430m,
                        @"Audi Q3 1.4 TFSI is a 2011 SUV model with 6 speed manual transmission.
                        With a power of 110 KW you can reach 0-100km h in just 9,2 seconds and a maximum speed of 203 km/h with an urban consumption of 7,4 l/100km.
                        The engine has a capacity of 1395 cc with 4, in line cylinders and 4 valves per cylinders.
                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.",
                        203,
                        1,
                        1
                ), // SUV, Audi

                new Car(2,
                        "Alfa Romeo 156 1.6 T.Spark 16V Progression",
                        2002,
                        24.685m,
                        @"Alfa Romeo 156 1.6 T.Spark 16V Progression is a 2002 Sedan model with 5 speed manual transmission.
                        With a power of 88 KW you can reach 0-100km h in just 10,5 seconds and a maximum speed of 200 km/h with an urban consumption of 11,4 l/100km.
                        The engine has a capacity of 1598 cc with 4, in line cylinders and 4 valves per cylinders.
                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.",
                        200,
                        2,
                        2
                ), // Sedan, Alfa Romeo

                new Car(3,
                        "Dodge Avenger 2.0 SE",
                        2007,
                        24.450m,
                        @"Dodge Avenger 2.0 SE is a 2007 Sedan model with 5 speed manual transmission.
                        With a power of 115 KW you can reach 0-100km h in just 10,8 seconds and a maximum speed of 200 km/h with an urban consumption of 10,7 l/100km.
                        The engine has a capacity of 1998 cc with 4, in line cylinders and 4 valves per cylinders.
                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.",
                        204,
                        2,
                        3
                ), // Sedan, Dodge

                new Car(4,
                        "BMW 840i Cabrio",
                        2019,
                        120.141m,
                        @"BMW 840i Cabrio is a 2019 Convertible model with 8 speed automatic.
                        With a power of 250 KW you can reach 0-100km h in just 5,3 seconds and a maximum speed of 250 km/h with an urban consumption of 9,1 l/100km.
                        The engine has a capacity of 2998 cc with 6, in line cylinders and 4 valves per cylinders.
                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.",
                        250,
                        3,
                        4
                ), // Convertible, BMW

                new Car(5,
                        "Hyundai Coupe 2.0i FX DynamicVersion",
                        2004,
                        26.195m,
                        @"Hyundai Coupe 2.0i FX DynamicVersion is a 2004 Coupe model with 5 speed manual transmission.
                        With a power of 105 KW you can reach 0-100km h in just 9,1 seconds and a maximum speed of 208 km/h with an urban consumption of 10,9 l/100km.
                        The engine has a capacity of 1975 cc with 4, in line cylinders and 4 valves per cylinders.
                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.",
                        208,
                        4,
                        5
                ), // Coupe, Hyundai

                new Car(6,
                        "Nissan Juke 1.6 Juke",
                        2010,
                        19.490m,
                        @"Nissan Juke 1.6 Juke is a 2010 SUV model with 5 speed manual transmission.
                        With a power of 68 KW you can reach 0-100km h in just 12,0 seconds and a maximum speed of 168 km/h with an urban consumption of 7,6 l/100km.
                        The engine has a capacity of 1598 cc with 4, in line cylinders and 4 valves per cylinders.
                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.",
                        168,
                        1,
                        6
                ), // SUV, Nissan
            };
            
            modelBuilder.Entity<CarBrand>()
                .HasData(carBrands);

            modelBuilder.Entity<CarBodyType>()
                .HasData(carBodyTypes);

            modelBuilder.Entity<Car>()
                .HasData(cars);
        }
    }
}
