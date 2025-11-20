namespace BillingProject_Backend.Domain.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string TipoCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string RFC { get; set; }
    }
}
