namespace BillingProject_Backend.Domain.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string imagenProducto { get; set; }
        public decimal ext { get; set; }
    }
}
