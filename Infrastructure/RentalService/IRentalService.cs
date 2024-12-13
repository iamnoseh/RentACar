using Domain;
using Infrastructure.ApiResponse;

namespace Infrastructure.RentalService;

public interface IRentalService
{
    public Response<bool> AddRental(Rental rental);
    public Response<Rental> GetRentalbyCustomerId(int id);
    public Response<List<Rental>> GetRentals();
}