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

        public bool UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            return Save();
        }

        public bool DeleteCar(int id)
        {
            _context.Cars.Remove(GetCar(id));
            return Save();
        }

        public bool DeleteCarBodyType(int id)
        {
            _context.CarBodyTypes.Remove(GetCarBodyType(id));
            return Save();
        }

        public bool DeleteCarBrand(int id)
        {
            _context.CarBrands.Remove(GetCarBrand(id));
            return Save();
        }

        public bool AddCar(int carBodyTypeId, int carBrandId, Car car)
        {
            car.CarBrandId = carBrandId;
            car.CarBodyTypeId = carBodyTypeId;
            _context.Cars.Add(car);
            return Save();
        }

        public bool AddCarBrand(CarBrand carBrand)
        {
            _context.CarBrands.Add(carBrand);
            return Save();
        }

        public bool AddCarBodyType(CarBodyType carBodyType)
        {
            _context.CarBodyTypes.Add(carBodyType);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
