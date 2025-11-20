using BillingProject_Backend.Domain.DTOs;

namespace BillingProject_Backend.Infrastructure.Repositories
{
    public interface ILookupRepository
    {
        Task<IEnumerable<ClienteDTO>> GetClientesAsync();
        Task<IEnumerable<ProductoDTO>> GetProductosAsync();
    }
}
