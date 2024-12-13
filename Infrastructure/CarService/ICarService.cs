using Domain;
using Infrastructure.ApiResponse;

namespace Infrastructure.CarService;

public interface ICarService
{
    public Response<bool> AddCar(Car car);
    public Response<bool> RemoveCar(int carId);
    public Response<bool> UpdateCar(Car car);
    public Response<Car> GetCarById(int carId);
    public Response<List<Car> > GetCars();
}