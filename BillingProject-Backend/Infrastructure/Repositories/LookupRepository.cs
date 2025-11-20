using System.Data;
using System.Data.SqlClient;
using BillingProject_Backend.Domain.DTOs;
using BillingProject_Backend.Infrastructure.Database;

namespace BillingProject_Backend.Infrastructure.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly IDbConnectionFactory _factory;

        public LookupRepository(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesAsync()
        {
            var result = new List<ClienteDTO>();
            using var conn = (SqlConnection)_factory.CreateConnection();
            using var cmd = new SqlCommand("sp_Clientes_Listar", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            await conn.OpenAsync();
            using var rdr = await cmd.ExecuteReaderAsync();

            while (await rdr.ReadAsync())
            {
                result.Add(new ClienteDTO
                {
                    Id = rdr.GetInt32(0),
                    RazonSocial = rdr.GetString(1),
                    TipoCliente = rdr.GetString(2)
                });
            }

            return result;
        }

        public async Task<IEnumerable<ProductoDTO>> GetProductosAsync()
        {
            var result = new List<ProductoDTO>();
            using var conn = (SqlConnection)_factory.CreateConnection();
            using var cmd = new SqlCommand("sp_Productos_Listar", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            await conn.OpenAsync();
            using var rdr = await cmd.ExecuteReaderAsync();

            while (await rdr.ReadAsync())
            {
                result.Add(new ProductoDTO
                {
                    Id = rdr.GetInt32(0),
                    NombreProducto = rdr.GetString(1),
                    PrecioUnitario = rdr.GetDecimal(2),
                });
            }
            return result;
        }

    }
}
