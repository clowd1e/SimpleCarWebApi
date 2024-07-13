using SimpleCarWebApi.Models;

namespace SimpleCarWebApi.Repository
{
    public interface ICarRepository
    {
        void AddCar(Car car);
        void DeleteCar(int id);
        Car GetCar(int id);
        IEnumerable<Car> GetAllCars();
        void UpdateCar(Car car);
        CarBodyType GetCarBodyType(int id);
        IEnumerable<CarBodyType> GetAllCarBodyTypes();
        CarBrand GetCarBrand(int id);
        IEnumerable<CarBrand> GetAllCarBrands();
        IEnumerable<Car> GetCarsByBrand(int brandId);
        IEnumerable<Car> GetCarsByBodyType(int bodyTypeId);
        void DeleteCarBrand(int id);
        void DeleteCarBodyType(int id);
    }
}
