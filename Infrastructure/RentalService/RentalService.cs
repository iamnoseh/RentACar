using Dapper;
using Domain;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.RentalService;

public class RentalService(DapperContext _context): IRentalService
{
    public bool AddRental(Rental rental)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Insert into rentals (car_id,customer_id,startdate,enddate,totalcost) values (@CarId,@CustomerId,@StartDate,@EndDate,@TotalCost)";
            int effect = context.Execute(cmd, rental);
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Rental? GetRentalbyCustomerId(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from rentals where customer_id=@CustomerId";
            var effect = context.Query<Rental>(cmd, new { CustomerId = id }).FirstOrDefault();
            return effect;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }   
    }
    

    public List<Rental> GetRentals()
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from rentals";
            var effect = context.Query<Rental>(cmd).ToList();
            return effect;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}