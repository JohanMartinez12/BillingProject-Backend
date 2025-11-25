namespace BillingProject_Backend.Domain.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string ext { get; set; }
        public string imagenProducto { get; set; }
        public int PrecioUnitario { get; set; }
    }
}
