using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace facturas
{
    // MODELO FACTURA
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string NombreCliente { get; set; } = "";
        public decimal Total { get; set; }
        public bool Archivada { get; set; } = false;
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }

    // MODELO ARTICULO
    public class Articulo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = "";
        public int Cantidad { get; set; } = 1;
        public decimal Precio { get; set; }
        public int FacturaId { get; set; }
    }

    // BASE DE DATOS
    public class FacturasDb : DbContext
    {
        public FacturasDb(DbContextOptions<FacturasDb> options) : base(options) { }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
    }
}