using CONSALUD.Models;
using Newtonsoft.Json;

namespace CONSALUD.Dal
{
    public class FacturaRepository
    {
        public static List<Factura> GetFacturas()
        {
            StreamReader reader = new StreamReader("JsonDB.json");
            string jsonString = reader.ReadToEnd();
            var facturas = JsonConvert.DeserializeObject<List<Factura>>(jsonString);

            foreach (var factura in facturas)
            {
                decimal totalFactura = 0;
                foreach (var detalle in factura.DetalleFactura)
                {
                    totalFactura += detalle.TotalProducto;
                }
                factura.TotalFactura = totalFactura;
            }
            return facturas;
        }
    }
}
