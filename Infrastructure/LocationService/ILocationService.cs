using Domain;
using Infrastructure.ApiResponse;

namespace Infrastructure.LocationService;

public interface ILocationService
{
    public Response<bool> AddLocation(Location location);
    public Response<bool> UpdateLocation(Location location);
    public Response<bool> DeleteLocation(int id);
    public Response<Location> GetLocationById(int id);
    public Response<List<Location>> GetLocations();
}