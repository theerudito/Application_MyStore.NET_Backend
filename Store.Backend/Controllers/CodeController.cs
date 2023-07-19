using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Models;
using Store.Utils;

namespace Store.Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CodeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GET_Codes()
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.AppCode.ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existen Registros"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GET_Code(int id)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.AppCode.Where(c => c.IdCode == id).FirstOrDefaultAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existe El Registro"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> GET_Code(MCode myCode)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.AppCode
                .Where(c => c.Code == myCode.Code)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var newCode = new MCode { Code = ApplicationCrypt.Encriptar(myCode.Code) };
                _contextDB.AppCode.Add(newCode);

                await _contextDB.SaveChangesAsync();

                return Ok(MessagesJSON.MessageOK("El Codigo Fue Añadido Correctamente"));
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("El Codigo Ya Existe"));
            }
        }

        [HttpPost("code")]
        public async Task<ActionResult> POST_Code_Code(MCode Code)
        {
            var _contextDB = new Application_ContextDB();
            var query = await _contextDB.AppCode
                .Where(c => c.Code == Code.Code)
                .FirstOrDefaultAsync();

            var newCode = new MCode { Code = ApplicationCrypt.Encriptar(Code.Code) };

            if (query != null)
            {
                if (query.Code == ApplicationCrypt.Encriptar(Code.Code))
                {
                    return BadRequest(MessagesJSON.MessageOK("El Codigo Es Correcto"));
                }
                else
                {
                    return BadRequest(MessagesJSON.MessageError("El Codigo Es Incorrecto"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe Registro"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUT_Code(MCode myCode)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.AppCode
                .Where(c => c.IdCode == myCode.IdCode)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdCode == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Operacion")
                    );
                }
                else
                {
                    var newCode = new MCode { Code = ApplicationCrypt.Encriptar(myCode.Code) };

                    await _contextDB.SaveChangesAsync();

                    return Ok(MessagesJSON.MessageOK("El Nuevo Codigo Fue Añadido Correctamente"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existe El Registro"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETE_Code(int id)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.AppCode.Where(c => c.IdCode == id).FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdCode == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Operacion")
                    );
                }
                else
                {
                    _contextDB.Remove(query);
                    await _contextDB.SaveChangesAsync();

                    return Ok(MessagesJSON.MessageOK("El Codigo Fue Eliminado Correctamente"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existe El Registro"));
            }
        }
    }
}
