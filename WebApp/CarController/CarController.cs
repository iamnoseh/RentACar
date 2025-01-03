using Domain;
using Infrastructure.ApiResponse;
using Infrastructure.CarService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.CarController;
[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService ):ControllerBase
{
    [HttpGet]
    public Response<List<Car> > GetCar()
    {
        var response =  carService.GetCars();
        return response;
    }

    [HttpGet("[action]/{id}")]
    public Response<Car> GetCarById(int id)
    {
        var response =  carService.GetCarById(id);
        return response;
    }

    [HttpPost]
    public Response<bool> AddCar(Car car)
    {
        var response =  carService.AddCar(car);
        return response;
    }

    [HttpPut]
    public Response<bool> UpdateCar(Car car)
    {
        var response =  carService.UpdateCar(car);
        return response;
    }

    [HttpDelete]
    public Response<bool> DeleteCar(int carId)
    {
        var response = carService.RemoveCar(carId);
        return response;
    }
}