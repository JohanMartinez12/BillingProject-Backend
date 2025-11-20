namespace BillingProject_Backend.Domain.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = default!;
        public string TipoCliente { get; set; } = default!;
    }
}
