using Service.Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Data;

namespace Parcial1_MelanieTorales.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService clienteService;

        public ClienteController(IConfiguration configuration)
        {
            clienteService = new ClienteService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpPost("AddCliente")]
        public ActionResult add([FromBody] Repository.Data.ClienteModel cliente) 
        {
            var response = clienteService.add(cliente);
            if (response.Success)
            {
                return Ok(new { message = response.Message});
            }else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("UpdateCliente")]
        public ActionResult update([FromBody] Repository.Data.ClienteModel cliente)
        {
            var response = clienteService.update(cliente);
            if (response.Success)
            {
                return Ok(new { message = response.Message });
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("DeleteCliente")]
        public ActionResult delete(int Id)
        {
            var response = clienteService.delete(Id);
            if (response.Success)
            {
                return Ok(new { message = response.Message });
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetCliente")]
        public ActionResult get(int Id)
        {
            var response = clienteService.get(Id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("ListCliente")]
        public List<ClienteModel> list()
        {
            return clienteService.list();
        }

    }
}
