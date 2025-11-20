using Microsoft.AspNetCore.Mvc;
using BillingProject_Backend.Infrastructure.Repositories;

namespace BillingProject_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly ILookupRepository _repo;

        public LookupController(ILookupRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> GetClientes()
        {
            var data = await _repo.GetClientesAsync();
            return Ok(data);
        }

        [HttpGet("productos")]
        public async Task<IActionResult> GetProductos()
        {
            var data = await _repo.GetProductosAsync();
            return Ok(data);
        }
    }
}
