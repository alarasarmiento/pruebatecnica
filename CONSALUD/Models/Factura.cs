using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CONSALUD.Models
{
    public class Factura
    {
        public decimal NumeroDocumento { get; set; }
        public decimal RUTVendedor { get; set; }
        public string DvVendedor { get; set; } = string.Empty;
        public decimal RUTComprador { get; set; }
        public string DvComprador { get; set; } = string.Empty;
        public string DireccionComprador { get; set; } = string.Empty;
        public decimal ComunaComprador { get; set; }
        public decimal RegionComprador { get; set; }
        public decimal TotalFactura { get; set; }
        public List<DetalleFactura> DetalleFactura { get; set; } 

    }
}
