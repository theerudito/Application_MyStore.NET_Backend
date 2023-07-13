using Microsoft.AspNetCore.Mvc;
using Store.DTO;
using Store.Service;
using Store.Utils;

namespace Store.Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GETClients()
        {
            var query = await _clientRepository.GetAllClients();
            return Ok(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GETClient(int id)
        {
            var clientExist = await _clientRepository.GetClientById(id);

            if (clientExist != null)
            {
                return Ok(clientExist);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe Cliente En La Base De Datos"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> POSTClient([FromBody] MClientsDTO client)
        {
            var clientExist = await _clientRepository.CreateClient(client);
            if (clientExist == null)
            {
                return BadRequest(MessagesJSON.MessageError("El Cliente Ya Esta Registrado"));
            }
            return Ok(MessagesJSON.MessageOK("El Cliente Fue Añadido Correctamente"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUTClient([FromBody] MClientsDTO client)
        {
            var clientExist = await _clientRepository.UpdateClient(client);

            if (clientExist != null)
            {
                if (clientExist.IdClient == 1)
                {
                    return BadRequest(MessagesJSON.MessageError("No Se Puede Realizar Esta Accion"));
                }
                else
                {
                    return Ok(MessagesJSON.MessageOK("El Cliente fue Actualizado"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe Cliente En La Base De Datos"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETEClient(int id)
        {
            var clientExist = await _clientRepository.DeleteClient(id);

            if (clientExist != null)
            {
                if (clientExist.IdClient == 1)
                {
                    return BadRequest(MessagesJSON.MessageError("No Se Puede Realizar Esta Accion"));
                }
                else
                {
                    if (clientExist.Status == true)
                    {
                        return Ok(MessagesJSON.MessageOK("El Cliente fue Activado"));
                    }
                    else
                    {
                        return Ok(MessagesJSON.MessageOK("El Cliente fue Desactivado"));
                    }
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe Cliente En La Base De Datos"));
            }
        }
    }
}