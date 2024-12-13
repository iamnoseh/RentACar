using Domain;
using Infrastructure.ApiResponse;
using Infrastructure.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.CustomerController;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService)
{
    [HttpGet]
    public Response<IEnumerable<Customer>> GetCustomers()
    {
        var customers = customerService.GetCustomers();
        return customers;
    }

    [HttpGet("[action]/{id}")]
    public Response<Customer> GetCustomer(int id)
    {
        var res = customerService.GetCustomerById(id);
        return res;
    }

    [HttpPost]
    public Response<bool> AddCustomer(Customer customer)
    {
        var res = customerService.AddCustomer(customer);
        return res;
    }

    [HttpPut]
    public Response<bool> UpdateCustomer(Customer customer)
    {
        var res = customerService.UpdateCustomer(customer);
        return res;
    }

    [HttpDelete]
    public Response<bool> DeleteCustomer(int id)
    {
        var res = customerService.DeleteCustomer(id);
        return res;
    }
}