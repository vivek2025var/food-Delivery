using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public interface IRiderRepository
    {
        Task<IEnumerable<Rider>> GetRiders();
        Task<Rider> GetRiderById(int id);
        Task<int> AddRider(Rider rider);
        Task<int> UpdateRider(Rider rider);
        Task<int> DeleteRider(int id);
    }
}
