using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;
using Npgsql;

namespace CoinRestAPI.Infrastructure.Data.Repositories
{
    public class LocationRepository : ConnectionRepository, ILocationRepository
    {
        public LocationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new NpgsqlCommand("SELECT * FROM GetCountries()", connection);
            using var reader = await command.ExecuteReaderAsync();
            var countries = new List<Country>();
            while (await reader.ReadAsync())
            {
                countries.Add(new Country
                {
                    id = reader["id"].ToString(),
                    name = reader["name"].ToString(),
                });
            }
            return countries;
        }

        public async Task<IEnumerable<State>> GetStatesByCountryAsync(string countryId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new NpgsqlCommand("SELECT * FROM GetStates(@id_country)", connection);
            command.Parameters.AddWithValue("id_country", countryId);
            using var reader = await command.ExecuteReaderAsync();
            var states = new List<State>();
            while (await reader.ReadAsync())
            {
                states.Add(new State
                {
                    id = Convert.ToInt32(reader["id"]),
                    country_id = reader["country_id"].ToString(),
                    name = reader["name"].ToString(),
                });
            }
            return states;
        }

        public async Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new NpgsqlCommand("SELECT * FROM GetCities(@id_state)", connection);
            command.Parameters.AddWithValue("id_state", stateId);
            using var reader = await command.ExecuteReaderAsync();
            var cities = new List<City>();
            while (await reader.ReadAsync())
            {
                cities.Add(new City
                {
                    id = Convert.ToInt32(reader["id"]),
                    state_id = Convert.ToInt32(reader["state_id"]),
                    name = reader["name"].ToString(),
                });
            }
            return cities;
        }
    }
}