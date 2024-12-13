using Dapper;
using Domain;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.CarLocationService;

public class CarLocationService(DapperContext _context): ICarLocationService
{
    public bool AddCarLocation(CarLocation carLocation)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Insert into carlocations(car_id,location_id) values (@CarId,@LocationId)";
            var effect = context.Execute(cmd, carLocation);
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteCarLocation(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Delete from carlocations where car_id=@CarId";
            var effect = context.Execute(cmd, new { CarId = id });
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<CarLocation> GetCarLocation()
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Select * from carlocations";
            var effect = context.Query<CarLocation>(cmd).ToList();
            return effect;
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}