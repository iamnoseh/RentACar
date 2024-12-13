using Domain;
using Infrastructure.RentalService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.RentalController;

[ApiController]
[Route("api/[controller]")]
public class RentalController(IRentalService rentalService):ControllerBase
{
    [HttpGet]
    public List<Rental> GetRental()
    {
        var result=rentalService.GetRentals();
        return result;
    }

    [HttpGet("[action]/{id}")]
    public Rental GetRentalById(int id)
    {
        var res = rentalService.GetRentalbyCustomerId(id);
        return res;
    }

    [HttpPost]
    public bool AddRental(Rental rental)
    {
        var result=rentalService.AddRental(rental);
        return result;
    }
    
    
}