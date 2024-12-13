using Domain;

namespace Infrastructure.RentalService;

public interface IRentalService
{
    public bool AddRental(Rental rental);
    public Rental? GetRentalbyCustomerId(int id);
    public List<Rental> GetRentals();
}