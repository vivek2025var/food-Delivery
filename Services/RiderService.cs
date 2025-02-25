using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class RiderService : IRiderService
    {
        private readonly IRiderRepository _riderRepository;

        public RiderService(IRiderRepository riderRepository)
        {
            _riderRepository = riderRepository;
        }

        public Task<IEnumerable<Rider>> GetRiders() => _riderRepository.GetRiders();
        public Task<Rider> GetRiderById(int id) => _riderRepository.GetRiderById(id);
        public Task<int> AddRider(Rider rider) => _riderRepository.AddRider(rider);
        public Task<int> UpdateRider(Rider rider) => _riderRepository.UpdateRider(rider);
        public Task<int> DeleteRider(int id) => _riderRepository.DeleteRider(id);
    }
}
