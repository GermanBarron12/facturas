using System.ComponentModel.DataAnnotations;

namespace facturas.Models
{
    // Esta es la clase principal - representa UNA factura
    public class Factura
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pon la fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Pon el nombre del cliente")]
        public string NombreCliente { get; set; } = "";

        public decimal Total { get; set; }

        // Una factura puede tener muchos artículos
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}