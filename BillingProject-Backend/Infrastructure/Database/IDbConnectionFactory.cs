using System.Data;
namespace BillingProject_Backend.Infrastructure.Database
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
