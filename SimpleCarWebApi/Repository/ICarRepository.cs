using SimpleCarWebApi.Models;

namespace SimpleCarWebApi.Repository
{
    public interface ICarRepository
    {
        bool AddCar(int carBodyTypeId, int carBrandId, Car car);
        bool DeleteCar(int id);
        Car GetCar(int id);
        IEnumerable<Car> GetAllCars();
        bool UpdateCar(Car car);
        CarBodyType GetCarBodyType(int id);
        IEnumerable<CarBodyType> GetAllCarBodyTypes();
        CarBrand GetCarBrand(int id);
        IEnumerable<CarBrand> GetAllCarBrands();
        IEnumerable<Car> GetCarsByBrand(int brandId);
        IEnumerable<Car> GetCarsByBodyType(int bodyTypeId);
        bool DeleteCarBrand(int id);
        bool DeleteCarBodyType(int id);
        bool AddCarBrand(CarBrand carBrand);
        bool AddCarBodyType(CarBodyType carBodyType);
        bool Save();
    }
}
