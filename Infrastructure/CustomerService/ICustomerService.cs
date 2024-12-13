using Domain;
using Infrastructure.ApiResponse;

namespace Infrastructure.CustomerService;

public interface ICustomerService
{
    public Response<bool> AddCustomer(Customer customer);
    public Response<bool> UpdateCustomer(Customer customer);
    public Response<bool> DeleteCustomer(int id);
    public Response<Customer> GetCustomerById(int id);
    public Response<IEnumerable<Customer>> GetCustomers();
}