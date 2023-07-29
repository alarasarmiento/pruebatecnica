namespace CONSALUD.Models
{
    public class DetalleFactura
    {
        public decimal CantidadProducto { get; set; }
        public Producto? Producto { get; set; }
        public decimal TotalProducto { get; set; } 
    }
}
