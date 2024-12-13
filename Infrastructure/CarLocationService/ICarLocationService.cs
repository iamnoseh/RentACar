using Domain;

namespace Infrastructure.CarLocationService;

public interface ICarLocationService
{
    public bool AddCarLocation(CarLocation carLocation);
    public bool DeleteCarLocation(int id);
    public List<CarLocation> GetCarLocation();
}