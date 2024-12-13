using Dapper;
using Domain;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.CustomerService;

public class CustomerService(DapperContext _context): ICustomerService
{
    public bool AddCustomer(Customer customer)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Insert into customers(fullname,phone,email) values (@FullName,@Phone,@Email)";
            int effect = context.Execute(cmd, customer);
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateCustomer(Customer customer)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Update customers (fullname,phone,email) values (@FullName,@Phone,@Email) where id = CustomerId";
            int effect = context.Execute(cmd, customer);
            return effect > 0; 
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteCustomer(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "Delete from customers(id) where id = @id";
            int effect = context.Execute(cmd, new { id });
            return effect > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Customer? GetCustomerById(int id)
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from customers(id) where id = @id";
            return context.Query<Customer>(cmd, new { id }).FirstOrDefault();
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<Customer> GetCustomers()
    {
        try
        {
            using var context = _context.GetConnection();
            string cmd = "select * from customers";
            var result = context.Query<Customer>(cmd);
            return result;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}