using Domain;
using Infrastructure.DataContext;
using Dapper;
using Npgsql;

namespace Infrastructure.CarService;

public class CarService(DapperContext _context):ICarService
{
    public bool AddCar(Car car)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd =
                "Insert into cars(model,manufacturer,year,priceperday) values (@model,@manufacturer,@year,@priceperday);";
            int effect = context.Execute(cmd, car);
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool RemoveCar(int carId)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = " Delete from cars where id=@carId; ";
            int effect = context.Execute(cmd, carId);
            return effect != 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateCar(Car car)
    {
        using var context = _context.GetConnection();
        string cmd = "Updaet cars model = @Model ,manufacturer = @Manufacturer,year = @Year,priceperday = PricePerDay) where @id=@Id; ";
        int effect = context.Execute(cmd, car);
        return effect > 0;
    }

    public Car? GetCarById(int carId)
    {
        using var context = _context.GetConnection();
        string cmd = "select * from cars where id=@carId; ";
        var car = context.QuerySingle<Car>(cmd, carId);
        return car;
    }

    public List<Car> GetCars()
    {
        using var context = _context.GetConnection();
        string cmd = "select * from cars;";
        var cars = context.Query<Car>(cmd).ToList();
        return cars;
    }
}