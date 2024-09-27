using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;

namespace CoinRestAPI.CORE.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _locationRepository.GetCountriesAsync();
        }

        public async Task<IEnumerable<State>> GetStatesByCountryAsync(string countryId)
        {
            return await _locationRepository.GetStatesByCountryAsync(countryId);
        }

        public async Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId)
        {
            return await _locationRepository.GetCitiesByStateAsync(stateId);
        }
    }
}