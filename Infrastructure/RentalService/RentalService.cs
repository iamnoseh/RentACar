using System.Net;
using Dapper;
using Domain;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.RentalService;

public class RentalService(DapperContext _context): IRentalService
{
    public Response<bool> AddRental(Rental rental)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Insert into rentals (car_id,customer_id,startdate,enddate,totalcost) values (@CarId,@CustomerId,@StartDate,@EndDate,@TotalCost)";
            int effect = context.Execute(cmd, rental);
            return effect == 0 
                ? new Response<bool>(HttpStatusCode.InternalServerError,"interval server error")
                : new Response<bool>(HttpStatusCode.Created,"Rental added successfully");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<Rental> GetRentalbyCustomerId(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from rentals where customer_id=@id";
            var effect = context.Query<Rental>(cmd, new { customer_id = id }).FirstOrDefault();
            if (effect == null)
            {
                return new Response<Rental>(HttpStatusCode.NotFound,"Rental not found");
            }
            return new Response<Rental>(effect);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }   
    }
    

    public Response<List<Rental>> GetRentals()
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from rentals";
            var effect = context.Query<Rental>(cmd).ToList();
            if (effect == null)
            {
                return new Response<List<Rental>>(HttpStatusCode.NotFound,"Rentals not found");
            }
            return new Response<List<Rental>>(effect);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}