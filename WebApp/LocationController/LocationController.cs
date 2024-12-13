using Domain;
using Infrastructure.LocationService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.LocationController;

[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationService locationService):ControllerBase
{
    [HttpGet]
    public List<Location> GetLocation()
    {
        var res = locationService.GetLocations();
        return res;
    }

    [HttpGet("[action]/{id}")]
    public Location GetLocationById(int id)
    {
        var res = locationService.GetLocationById(id);
        return res;
    }

    [HttpPost]
    public bool AddLocation(Location location)
    {
        var res = locationService.AddLocation(location);
        return res;
    }

    [HttpPut]
    public bool UpdateLocation(Location location)
    {
        var res = locationService.UpdateLocation(location);
        return res;
    }

    [HttpDelete]
    public bool DeleteLocation(int id)
    {
        var res = locationService.DeleteLocation(id);
        return res;
    }
}