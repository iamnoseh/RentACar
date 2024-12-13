using Domain;
using Infrastructure.CarLocationService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.CarLocationController;

[ApiController]
[Route("api/[controller]")]
public class CarLocationController(ICarLocationService carLocationService):ControllerBase
{
    [HttpGet]
    public List<CarLocation> GetLocations()
    {
        var res = carLocationService.GetCarLocation();
        return res;
    }

    [HttpPost]
    public bool AddCarLocation(CarLocation carLocation)
    {
        var res = carLocationService.AddCarLocation(carLocation);
        return res;
    }

    [HttpDelete]
    public bool DeleteCarLocation(int id)
    {
        var res = carLocationService.DeleteCarLocation(id);
        return res;
    }
    
}
