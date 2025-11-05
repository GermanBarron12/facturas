using System.ComponentModel.DataAnnotations;

namespace facturas.Models
{
    // Esta clase representa UN artículo dentro de una factura
    public class Articulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Describe el artículo")]
        public string Descripcion { get; set; } = "";

        [Required]
        [Range(1, 1000, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad { get; set; } = 1;

        [Required]
        [Range(0.01, 999999, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        // A qué factura pertenece este artículo
        public int FacturaId { get; set; }
    }
}