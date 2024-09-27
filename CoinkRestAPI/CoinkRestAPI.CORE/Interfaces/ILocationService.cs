using CoinkRestAPI.CORE.Entities;

namespace CoinkRestAPI.CORE.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<IEnumerable<State>> GetStatesByCountryAsync(string countryId);
        Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId);
    }

    public interface ILocationRepository
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<IEnumerable<State>> GetStatesByCountryAsync(string countryId);
        Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId);
    }
}