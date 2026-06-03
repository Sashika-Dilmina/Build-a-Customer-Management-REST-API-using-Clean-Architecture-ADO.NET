using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namspace CustomerManagement.Infrastructure.Persistence;

public interface IDbConnectionFactory
{
    SqlConnection CreateConnection();
}

public class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' was not found.");
    }

    public SqlConnectionFactory CreateConnection() => new(_connectionString);

}



