using System.Net;
using Dapper;
using Domain;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.LocationService;

public class LocationService(DapperContext _context): ILocationService
{
    public Response<bool> AddLocation(Location location)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "insert into location(city,address) values(@City,@Address);";
            int effect = context.Execute(cmd, location);
            return effect == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
                : new Response<bool>(HttpStatusCode.Created, $"Location added successfully");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<bool> UpdateLocation(Location location)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "update location set city=@City,address=@Address where id=@Id;";
            int effect = context.Execute(cmd, location);
            return effect == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
                : new Response<bool>(HttpStatusCode.OK, $"Location updated successfully");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<bool> DeleteLocation(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "delete from location where id=@id;";
            int effect = context.Execute(cmd, new { id = id });
            return effect == 0 
                ? new Response<bool>(HttpStatusCode.NotFound, " Resource not found")
                : new Response<bool>(HttpStatusCode.OK, $"Location deleted successfully");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<Location> GetLocationById(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from location where id=@id;";
            var results = context.Query<Location>(cmd, new { id = id }).FirstOrDefault();
            if (results is null)
            {
                return new Response<Location>(HttpStatusCode.NotFound, " Resource not found");
            }
            return new Response<Location>(results);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<List<Location>> GetLocations()
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from location;";
            var locations = context.Query<Location>(cmd).ToList();
            if (locations is null)
            {
                return new Response<List<Location>>(HttpStatusCode.NotFound, " Resource not found");
            }
            return new Response<List<Location>>(locations);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}