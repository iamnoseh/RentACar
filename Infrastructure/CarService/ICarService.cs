using Domain;

namespace Infrastructure.CarService;

public interface ICarService
{
    public bool AddCar(Car car);
    public bool RemoveCar(int carId);
    public bool UpdateCar(Car car);
    public Car? GetCarById(int carId);
    public List<Car> GetCars();
}