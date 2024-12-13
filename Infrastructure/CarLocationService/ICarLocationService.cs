using Domain;
using Infrastructure.ApiResponse;

namespace Infrastructure.CarLocationService;

public interface ICarLocationService
{
    public Response<bool> AddCarLocation(CarLocation carLocation);
    public Response<bool> DeleteCarLocation(int id);
    public Response<List<CarLocation>> GetCarLocation();
}