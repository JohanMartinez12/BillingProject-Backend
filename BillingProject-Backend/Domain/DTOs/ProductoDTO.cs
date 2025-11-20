namespace BillingProject_Backend.Domain.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = default!;
        public decimal PrecioUnitario { get; set; }
    }
}
