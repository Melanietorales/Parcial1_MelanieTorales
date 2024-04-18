using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Service.Logica;

namespace Parcial1_MelanieTorales.Controllers
{
    public class FacturaController : Controller
    {
        private FacturaService facturaService;

        public FacturaController(IConfiguration configuration)
        {
            facturaService = new FacturaService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpPost("AddFactura")]
        public ActionResult add([FromBody] FacturaModel factura)
        {
            var response = facturaService.add(factura);
            if (response.Success)
            {
                return Ok(new { message = response.Message });
            }
            else
            {
                return BadRequest(response.Message);

            }
        }

        [HttpPost("UpdateFactura")]
        public ActionResult update([FromBody] FacturaModel factura)
        {
            var response = facturaService.update(factura);
            if (response.Success)
            {
                return Ok(new { message = response.Message });
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("DeleteFactura")]
        public ActionResult delete(int Id) 
        {
            var response = facturaService.delete(Id);
            if (response.Success)
            {
                return Ok(new { message = response.Message });
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetFactura")]
        public ActionResult get(int Id)
        {
            var response = facturaService.get(Id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("ListFactura")]
        public List<FacturaModel> list()
        {
            return facturaService.list();
        }
    }
}
