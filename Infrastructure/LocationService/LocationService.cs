using Dapper;
using Domain;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.LocationService;

public class LocationService(DapperContext _context): ILocationService
{
    public bool AddLocation(Location location)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "insert into location(city,address) values(@City,@Address);";
            int effect = context.Execute(cmd, location);
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateLocation(Location location)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "update location set city=@City,address=@Address where id=@LocationId;";
            int effect = context.Execute(cmd, location);
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteLocation(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "delete from location where id=@id;";
            int effect = context.Execute(cmd, id);
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Location? GetLocationById(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from location where id=@id;";
            return context.Query<Location>(cmd, new {id = id}).FirstOrDefault();
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Location> GetLocations()
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from location;";
            var locations = context.Query<Location>(cmd).ToList();
            return locations;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}