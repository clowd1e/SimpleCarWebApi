using SimpleCarWebApi.Data;
using SimpleCarWebApi.Models;

namespace SimpleCarWebApi.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;
        public CarRepository(CarDbContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }
        public Car GetCar(int id)
        {
            return _context.Cars.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<CarBodyType> GetAllCarBodyTypes()
        {
            return _context.CarBodyTypes.ToList();
        }

        public IEnumerable<CarBrand> GetAllCarBrands()
        {
            return _context.CarBrands.ToList();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public CarBodyType GetCarBodyType(int id)
        {
            return _context.CarBodyTypes.Where(c => c.Id == id).FirstOrDefault();
        }

        public CarBrand GetCarBrand(int id)
        {
            return _context.CarBrands.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Car> GetCarsByBodyType(int bodyTypeId)
        {
            return _context.Cars.Where(c => c.CarBodyTypeId == bodyTypeId).ToList();
        }

        public IEnumerable<Car> GetCarsByBrand(int brandId)
        {
            return _context.Cars.Where(c => c.CarBrandId == brandId).ToList();
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            _context.Cars.Remove(GetCar(id));
            _context.SaveChanges();
        }

        public void DeleteCarBodyType(int id)
        {
            _context.CarBodyTypes.Remove(GetCarBodyType(id));
            _context.SaveChanges();
        }

        public void DeleteCarBrand(int id)
        {
            _context.CarBrands.Remove(GetCarBrand(id));
            _context.SaveChanges();
        }
    }
}
