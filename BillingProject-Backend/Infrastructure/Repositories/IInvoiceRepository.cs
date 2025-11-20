using BillingProject_Backend.Domain.DTOs;

namespace BillingProject_Backend.Infrastructure.Repositories
{
    public interface IInvoiceRepository
    {
        Task<int> CreateInvoiceAsync(FacturaCreateDTO factura);
    }
}
