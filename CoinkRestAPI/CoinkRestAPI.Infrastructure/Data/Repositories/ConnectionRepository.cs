namespace CoinRestAPI.Infrastructure.Data.Repositories
{
    public abstract class ConnectionRepository
    {
        protected readonly string _connectionString;

        protected ConnectionRepository(IConfiguration configuration)
        {
            string host = configuration["HOST"];
            string username = configuration["USERNAME"];
            string password = configuration["PWD"];
            _connectionString = $"Host={host};Database=userregistration;Username={username};Password={password};";
        }
    }
}