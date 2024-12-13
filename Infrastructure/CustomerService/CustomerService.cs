using System.Net;
using Dapper;
using Domain;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.CustomerService;

public class CustomerService(DapperContext _context): ICustomerService
{
    public Response<bool> AddCustomer(Customer customer)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Insert into customers(fullname,phone,email) values (@FullName,@Phone,@Email)";
            int effect = context.Execute(cmd, customer);
            return effect == 0
                ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<bool>(HttpStatusCode.Created, "Customer Inserted");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<bool> UpdateCustomer(Customer customer)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Update customers set (fullname,phone,email) values (@FullName,@Phone,@Email) where id = CustomerId";
            int effect = context.Execute(cmd, customer);
            return effect == 0
                ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<bool>(HttpStatusCode.OK, "Customer Updated");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<bool> DeleteCustomer(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Delete from customers(id) where id = @id";
            int effect = context.Execute(cmd, new { id });
            return  effect == 0 
                ? new Response<bool>(HttpStatusCode.NotFound,"Customer Not Found!")
                : new Response<bool>(HttpStatusCode.OK,"Customer Deleted");
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<Customer> GetCustomerById(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from customers(id) where id = @id";
            var results = context.Query<Customer>(cmd, new { id }).FirstOrDefault();
            if (results is null)
            {
                return new Response<Customer>(HttpStatusCode.NotFound, "Customer Not Found!");
            }
            return new Response<Customer>(results);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Response<IEnumerable<Customer>> GetCustomers()
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from customers";
            var result = context.Query<Customer>(cmd);
            if (result is null)
            {
                
                return new Response<IEnumerable<Customer>>(HttpStatusCode.NotFound, "Customer Not Found!");
            }
            return new Response<IEnumerable<Customer>>(result);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}