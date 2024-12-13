using Domain;

namespace Infrastructure.CustomerService;

public interface ICustomerService
{
    public bool AddCustomer(Customer customer);
    public bool UpdateCustomer(Customer customer);
    public bool DeleteCustomer(int id);
    public Customer? GetCustomerById(int id);
    public IEnumerable<Customer> GetCustomers();
}