using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Models;
using Store.Utils;

namespace Store.Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly Application_ContextDB _contextDB;

        public CityController(Application_ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
        }

        [HttpGet]
        public async Task<ActionResult> GET_Cities()
        {
            var query = await _contextDB.Cities.ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existes Datos"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GET_City(int id)
        {
            var query = await _contextDB.Cities.Where(c => c.IdCity == id).FirstOrDefaultAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe Categoria"));
            }
        }

        [HttpGet("city")]
        public async Task<ActionResult> GET_City_Name(string city)
        {
            var query = await _contextDB.Cities
                .Where(c => c.City.Contains(city.ToUpper()))
                .ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe Categoria"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> POST_City(MCity myCity)
        {
            var query = await _contextDB.Cities
                .Where(c => c.City == myCity.City.ToUpper())
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var newCity = new MCity { City = myCity.City.ToUpper() };

                _contextDB.Cities.Add(newCity);

                await _contextDB.SaveChangesAsync();

                return Ok(MessagesJSON.MessageOK("La Ciudad Fue Añadida Correctamente"));
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("Ya Existe La Categoria"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUT_City(MCity myCity)
        {
            var query = await _contextDB.Cities
                .Where(c => c.IdCity == myCity.IdCity)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdCity == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Operacion")
                    );
                }
                else
                {
                    query.City = myCity.City.ToUpper();

                    await _contextDB.SaveChangesAsync();

                    return Ok(MessagesJSON.MessageOK("La Ciudad Fue Actualizada Correctamente"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe Categoria"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETE_City(int id)
        {
            var query = await _contextDB.Cities.Where(c => c.IdCity == id).FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdCity == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Operacion")
                    );
                }
                else
                {
                    _contextDB.Remove(query);

                    await _contextDB.SaveChangesAsync();

                    return Ok(MessagesJSON.MessageOK("La Ciudad Fue Eliminada Correctamente"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("Ya Existe Categoria"));
            }
        }
    }
}
