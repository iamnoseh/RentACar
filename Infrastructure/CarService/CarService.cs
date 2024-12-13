using System.Net;
using Domain;
using Infrastructure.DataContext;
using Dapper;
using Infrastructure.ApiResponse;
using Npgsql;

namespace Infrastructure.CarService;

public class CarService(DapperContext _context):ICarService
{
    public Response<bool> AddCar(Car car)
    {
        try
        {
            using var context = _context.GetConnection();
            string? cmd =
                "Insert into cars(model,manufacturer,year,priceperday) values (@Model,@Manufacturer,@Year,@PricePerDay);";
            int effect = context.Execute(cmd, car);
            return effect == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<bool>(HttpStatusCode.Created, "Car added successfully");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<bool> RemoveCar(int carId)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = " Delete from cars where id=@carId; ";
            int effect = context.Execute(cmd, carId);
            return effect == 0
                ? new Response<bool>(HttpStatusCode.NotFound,"Car not found!")
                : new Response<bool>(HttpStatusCode.OK, "Car deleted successfully");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<bool> UpdateCar(Car car)
    {
        using var context = _context.GetConnection();
        string cmd = "Update cars set model = @Model ,manufacturer = @Manufacturer,year = @Year,priceperday = PricePerDay where id=@Id; ";
        int effect = context.Execute(cmd, car);
        return effect == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<bool>(HttpStatusCode.OK, "Car updated successfully");
    }

    public Response<Car> GetCarById(int carId)
    {
        using var context = _context.GetConnection();
        string cmd = "select * from cars where id=@carId; ";
        var car = context.QuerySingle<Car>(cmd, new {carId});
        if (car == null)
        {
            return new Response<Car>(HttpStatusCode.NotFound,"Car not found!");
        }

        return new Response<Car>(car);
    }

    public Response<List<Car>> GetCars()
    {
        using var context = _context.GetConnection();
        string cmd = "select * from cars;";
        var cars = context.Query<Car>(cmd).ToList();
        if (cars == null)
        {
            return new Response<List<Car>>(HttpStatusCode.NotFound,"Car not found!");
        }
        return new Response<List<Car>>(cars);
    }
    
}