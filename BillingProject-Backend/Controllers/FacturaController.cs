using Microsoft.AspNetCore.Mvc;
using BillingProject_Backend.Infrastructure.Repositories;
using BillingProject_Backend.Domain.DTOs;

namespace BillingProject_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IInvoiceRepository _repo;
        public FacturaController(IInvoiceRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("crear")]
        public async Task<IActionResult> CreateFactura([FromBody] FacturaCreateDTO factura)
        {
            var idFactura = await _repo.CreateInvoiceAsync(factura);
            return Ok(new { id = idFactura });
        }
    
    }
}
