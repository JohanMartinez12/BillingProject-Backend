namespace BillingProject_Backend.Domain.DTOs
{
    public class DetalleFacturaDTO
    {
        public int IdProducto { get; set; }
        public int CantidadDeProducto { get; set; }
        public decimal PrecioUnitarioProducto { get; set; }
        public decimal SubtotalProducto { get; set; }
        public string? Notas { get; set; }
    }
}
