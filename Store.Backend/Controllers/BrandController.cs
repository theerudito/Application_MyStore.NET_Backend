using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Models;
using Store.Utils;

namespace Store.Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BrandController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GET_Brands()
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Brands.ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existen Datos"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GET_Brand(int id)
        {
            var _contextDB = new Application_ContextDB();
            var query = await _contextDB.Brands.Where(b => b.IdBrand == id).FirstOrDefaultAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe La Marca"));
            }
        }

        [HttpGet("brand")]
        public async Task<ActionResult> GET_Brans_Name(string brand)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Brands
                .Where(b => b.Brand.Contains(brand.ToUpper()))
                .ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe La Marca"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> POST_Brand(MBrand mybrand)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Brands
                .Where(b => b.Brand == mybrand.Brand.ToUpper())
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var newBrand = new MBrand { Brand = mybrand.Brand.ToUpper() };

                _contextDB.Brands.Add(newBrand);

                await _contextDB.SaveChangesAsync();

                return Ok(MessagesJSON.MessageOK("La Marca Fue Añadida Correctamente"));
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("Ya Existe La Marca"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUT_Brand(MBrand mybrand)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Brands
                .Where(b => b.IdBrand == mybrand.IdBrand)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdBrand == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Operacion")
                    );
                }
                else
                {
                    query.Brand = mybrand.Brand.ToUpper();

                    await _contextDB.SaveChangesAsync();

                    return Ok(MessagesJSON.MessageOK("La Marca Fue Actualizada Con Exito"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe La Marca"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETE_Brand(int id)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Brands.Where(b => b.IdBrand == id).FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdBrand == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Operacion")
                    );
                }
                else
                {
                    _contextDB.Remove(query);

                    await _contextDB.SaveChangesAsync();

                    return Ok(MessagesJSON.MessageOK("La Marca Fue Eliminada Correctamente"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe La Marca"));
            }
        }
    }
}
