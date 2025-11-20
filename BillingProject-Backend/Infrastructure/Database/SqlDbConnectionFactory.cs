using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BillingProject_Backend.Infrastructure.Database
{
    public class SqlDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlDbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    
    }
}
