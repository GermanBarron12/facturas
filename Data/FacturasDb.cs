using Microsoft.EntityFrameworkCore;
using facturas.Models;

namespace facturas.Data
{
    // Esta clase maneja la conexión con la base de datos
    public class FacturasDb : DbContext
    {
        public FacturasDb(DbContextOptions<FacturasDb> options) : base(options)
        {
        }

        // Estas son las "tablas" de la base de datos
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
    }
}