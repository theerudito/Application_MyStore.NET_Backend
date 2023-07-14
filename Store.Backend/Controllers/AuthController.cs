using Microsoft.AspNetCore.Mvc;
using Store.DTO;
using Store.Models;
using Store.Service;
using Store.Utils;

namespace Store.Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> POSTRegister([FromBody] MAuth auth)
        {
            var query = await _authRepository.Register(auth);

            if (query == null)
            {
                return BadRequest(MessagesJSON.MessageError("El Usuario Ya Esta Registrado"));
            }
            else
            {
                return Ok(MessagesJSON.MessageOK("El Registro Fue Añadido Correctamente"));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> POSTLogin([FromBody] MAuthDTO auth)
        {
            var query = await _authRepository.Login(auth);

            if (query != null)
            {
                return Ok(MessagesJSON.MessageOK("Logiado Con Exito"));
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("Usuario O Password Son Incorrectos"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> GETUsers()
        {
            var query = await _authRepository.GetAllUsers();
            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Hay Registros"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GETUser(int id)
        {
            var query = await _authRepository.GetUserById(id);
            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Hay Ningun Registro Con Ese ID"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUTUser([FromBody] MAuth auth)
        {
            var query = await _authRepository.UpdateUser(auth);
            if (query != null)
            {
                if (query.IdAuth == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Opcion")
                    );
                }
                else
                {
                    return Ok(MessagesJSON.MessageOK("El Registro Fue Actualizado Correctamente"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Hay Ningun Registro Con Ese ID"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETEUser(int id)
        {
            var query = await _authRepository.DeleteUser(id);

            if (query != null)
            {
                if (query.IdAuth == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Opcion")
                    );
                }
                else
                {
                    if (query.Status == true)
                    {
                        return Ok(MessagesJSON.MessageOK("El Registro Activado"));
                    }
                    else
                    {
                        return Ok(MessagesJSON.MessageOK("El Registro Fue Desactivado"));
                    }
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Hay Ningun Registro Con Ese ID"));
            }
        }
    }
}
