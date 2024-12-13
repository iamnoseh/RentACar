using Domain;

namespace Infrastructure.LocationService;

public interface ILocationService
{
    public bool AddLocation(Location location);
    public bool UpdateLocation(Location location);
    public bool DeleteLocation(int id);
    public Location? GetLocationById(int id);
    public List<Location> GetLocations();
}