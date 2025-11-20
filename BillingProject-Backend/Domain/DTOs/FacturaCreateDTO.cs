namespace BillingProject_Backend.Domain.DTOs
{
    public class FacturaCreateDTO
    {
        public DateTime FechaEmisionFactura { get; set; }
        public int IdCliente { get; set; }
        public int NumeroFactura { get; set; }
        public int NumeroTotalArticulos { get; set; }
        public decimal SubTotalFacturas { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal TotalFactura { get; set; }

        public List<DetalleFacturaDTO> Detalles { get; set; } = new();
    }
}
