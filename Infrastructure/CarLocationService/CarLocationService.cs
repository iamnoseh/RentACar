using System.Net;
using Dapper;
using Domain;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.CarLocationService;

public class CarLocationService(DapperContext _context): ICarLocationService
{
    public Response<bool> AddCarLocation(CarLocation carLocation)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Insert into carlocations(car_id,location_id) values (@CarId,@LocationId)";
            var effect = context.Execute(cmd, carLocation);
            return effect == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal server error!") 
                : new Response<bool>(HttpStatusCode.Created , "Successfully added carlocation!"); 
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public  Response<bool> DeleteCarLocation(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Delete from carlocations where car_id=@id";
            var effect = context.Execute(cmd, new { car_id = id });
            return effect == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal server error!")
                : new Response<bool>(HttpStatusCode.OK , "Successfully deleted carlocation!");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<List<CarLocation>> GetCarLocation()
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Select * from carlocations";
            var effect = context.Query<CarLocation>(cmd).ToList();
            if (effect == null)
            {
                return new Response<List<CarLocation>>(HttpStatusCode.InternalServerError,"Internal server error!");
            }
            return new Response<List<CarLocation>>(effect);
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}