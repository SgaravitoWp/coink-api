using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;
using CoinkRestAPI.CORE.DTOs;
using Npgsql;

namespace CoinRestAPI.Infrastructure.Data.Repositories
{
    public class UserRepository : ConnectionRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<User> CreateUserAsync(UserPost user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("SELECT * FROM InsertUser(@id_user, @name, @phone, @address, @id_country, @id_state, @id_city)", connection))
                {
                    command.Parameters.AddWithValue("id_user", user.user_id);
                    command.Parameters.AddWithValue("name", user.name);
                    command.Parameters.AddWithValue("phone", user.phone);
                    command.Parameters.AddWithValue("address", user.address);
                    command.Parameters.AddWithValue("id_country", user.country_id);
                    command.Parameters.AddWithValue("id_state", user.state_id);
                    command.Parameters.AddWithValue("id_city", user.city_id);
                    
                    var user_id = (string)await command.ExecuteScalarAsync();

                    return new User
                    {
                        id = user_id,
                        user_id = user.user_id,
                        name = user.name,
                        phone = user.phone,
                        address = user.address,
                        country_id = user.country_id,
                        state_id = user.state_id,
                        city_id = user.city_id,
                    };
                    

                    
                }
            }
        }
    }
}