using CONSALUD.Authentication;
using CONSALUD.Dal;
using CONSALUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace CONSALUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {  
        [HttpGet("GetFacturas")]
        public IActionResult GetFacturas()
        { 
            List<Factura> facturas = FacturaRepository.GetFacturas();

            if (facturas.Count > 0)
                return Ok(facturas);
            else return BadRequest("No Existen Facturas");
        }

        [HttpGet("GetFacturasporComprador")]
        public IActionResult GetFacturasporComprador(int rut)
        {
            List<Factura> facturas = FacturaRepository.GetFacturas();
            List<Factura> facturaComprador = new List<Factura>();

            foreach (var factura in facturas)
            {
                if (factura.RUTComprador == rut)
                {
                    facturaComprador.Add(factura);
                }
            }

            if(facturaComprador.Count > 0)
                return Ok(facturaComprador);
            else return BadRequest("Rut No Existe");
        }

        [HttpGet("GetCompradorConMasCompras")]
        public IActionResult GetCompradorConMasCompras()
        {
            List<Factura> facturas = FacturaRepository.GetFacturas();

            var resultado = facturas.GroupBy(x => x.RUTComprador)
                 .Select(g => new { Text = g.Key, Count = g.Count() }).ToList();

            int rut = 0;
            int maximo = 0;
            foreach(var registro in resultado)
            {
                if(registro.Count > maximo)
                {
                    rut = Convert.ToInt32(registro.Text);
                    maximo = registro.Count;
                }
            }

            if (resultado.Count > 0)
                return Ok(rut);
            else return BadRequest("No Existen Facturas");
        }

        [HttpGet("GetCompradoryTotalCompras")]
        public IActionResult GetCompradoryTotalCompras()
        {
            List<Factura> facturas = FacturaRepository.GetFacturas();

            var resultado = facturas.GroupBy(x => x.RUTComprador)
                 .Select(g => new { Rut = g.Key, MontoTotal = g.Sum(x => x.TotalFactura)
                 }).ToList(); 

            if (resultado.Count > 0)
                return Ok(resultado);
            else return BadRequest("No Existen Facturas");
        }

        [HttpGet("GetFacturasAgrupadasPorComuna")]
        public IActionResult GetFacturasAgrupadasPorComuna()
        {
            List<Factura> facturas = FacturaRepository.GetFacturas();

            var resultado = facturas.GroupBy(x => x.ComunaComprador).ToList();

            if (resultado.Count > 0)
                return Ok(resultado);
            else return BadRequest("No Existen Facturas");
        }

        [HttpGet("GetFacturaPorComuna")]
        public IActionResult GetFacturaPorComuna(int comuna)
        {
            List<Factura> facturas = FacturaRepository.GetFacturas();
            List<Factura> resultado = new List<Factura>();

            foreach (var factura in facturas)
            {
                if(Convert.ToInt32(factura.ComunaComprador) == comuna)
                {
                    resultado.Add(factura);
                }
            }

            if (resultado.Count > 0)
                return Ok(resultado);
            else return BadRequest("No Existen Facturas");
        }


    }
}
