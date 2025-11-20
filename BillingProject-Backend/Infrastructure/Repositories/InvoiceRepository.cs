using System.Data;
using System.Data.SqlClient;
using BillingProject_Backend.Domain.DTOs;
using BillingProject_Backend.Infrastructure.Database;

namespace BillingProject_Backend.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IDbConnectionFactory _factory;

        public InvoiceRepository(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<int> CreateInvoiceAsync(FacturaCreateDTO factura)
        {
            using var conn = (SqlConnection)_factory.CreateConnection();
            using var cmd = new SqlCommand("sp_Factura_CrearConDetalles", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            //Parameters
            cmd.Parameters.AddWithValue("@FechaEmisionFactura", factura.FechaEmisionFactura);
            cmd.Parameters.AddWithValue("@IdCliente", factura.IdCliente);
            cmd.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
            cmd.Parameters.AddWithValue("@NumeroTotalArticulos", factura.NumeroTotalArticulos);
            cmd.Parameters.AddWithValue("@SubTotalFacturas", factura.SubTotalFacturas);
            cmd.Parameters.AddWithValue("@TotalImpuestos", factura.TotalImpuestos);
            cmd.Parameters.AddWithValue("@TotalFactura", factura.TotalFactura);

            // Create the TVP (table-valued parameter) - MiniTable Temporal para mandar al StoredProcedure
            var detalles = new DataTable();
            detalles.Columns.Add("IdProducto", typeof(int));
            detalles.Columns.Add("CantidadDeProducto", typeof(int));
            detalles.Columns.Add("PrecioUnitarioProducto", typeof(decimal));
            detalles.Columns.Add("SubtotalProducto", typeof(decimal));
            detalles.Columns.Add("Notas", typeof(string));

            foreach (var d in factura.Detalles)
            {
                detalles.Rows.Add(
                    d.IdProducto,
                    d.CantidadDeProducto,
                    d.PrecioUnitarioProducto,
                    d.SubtotalProducto,
                    d.Notas
                );
            }

            var p = cmd.Parameters.AddWithValue("@Detalles", detalles);
            p.SqlDbType = SqlDbType.Structured;
            p.TypeName = "dbo.TVP_DetalleFactura";

            await conn.OpenAsync();
            var idFactura = (int)(await cmd.ExecuteScalarAsync());

            return idFactura;
        }
    }
}
