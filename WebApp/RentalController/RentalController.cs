using Domain;
using Infrastructure.ApiResponse;
using Infrastructure.RentalService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.RentalController;

[ApiController]
[Route("api/[controller]")]
public class RentalController(IRentalService rentalService):ControllerBase
{
    [HttpGet]
    public Response<List<Rental>> GetRental()
    {
        var result=rentalService.GetRentals();
        return result;
    }

    [HttpGet("[action]/{id}")]
    public Response<Rental> GetRentalById(int id)
    {
        var res = rentalService.GetRentalbyCustomerId(id);
        return res;
    }

    [HttpPost]
    public Response<bool> AddRental(Rental rental)
    {
        var result=rentalService.AddRental(rental);
        return result;
    }
    
    
}