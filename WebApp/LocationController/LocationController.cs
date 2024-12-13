using Domain;
using Infrastructure.ApiResponse;
using Infrastructure.LocationService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.LocationController;

[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationService locationService):ControllerBase
{
    [HttpGet]
    public Response<List<Location>> GetLocation()
    {
        var res = locationService.GetLocations();
        return res;
    }

    [HttpGet("[action]/{id}")]
    public Response<Location> GetLocationById(int id)
    {
        var res = locationService.GetLocationById(id);
        return res;
    }

    [HttpPost]
    public Response<bool> AddLocation(Location location)
    {
        var res = locationService.AddLocation(location);
        return res;
    }

    [HttpPut]
    public Response<bool> UpdateLocation(Location location)
    {
        var res = locationService.UpdateLocation(location);
        return res;
    }

    [HttpDelete]
    public Response<bool> DeleteLocation(int id)
    {
        var res = locationService.DeleteLocation(id);
        return res;
    }
}