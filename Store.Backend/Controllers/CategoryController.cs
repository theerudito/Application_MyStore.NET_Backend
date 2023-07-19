using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Models;
using Store.Utils;

namespace Store.Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GET_Categories()
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Categories.ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existen Datos"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GET_Category(int id)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Categories
                .Where(c => c.IdCategory == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existe La Categoria"));
            }
        }

        [HttpGet("category")]
        public async Task<ActionResult> GET_Category_Name(string category)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Categories
                .Where(c => c.Category.Contains(category))
                .ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existe La Categoria"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> POST_Category(MCategory mycategory)
        {
            var _contextDB = new Application_ContextDB();
            var query = await _contextDB.Categories
                .Where(c => c.Category == mycategory.Category)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                _contextDB.Categories.Add(mycategory);

                await _contextDB.SaveChangesAsync();
                return Ok(MessagesJSON.MessageOK("La Categoria Fue Agregada Correctamente"));
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existe La Categoria"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUT_Category(MCategory mycategory)
        {
            var _contextDB = new Application_ContextDB();
            var query = await _contextDB.Categories
                .Where(c => c.IdCategory == mycategory.IdCategory)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdCategory == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Opcion")
                    );
                }
                else
                {
                    query.Category = mycategory.Category;

                    await _contextDB.SaveChangesAsync();

                    return BadRequest(
                        MessagesJSON.MessageOK("La Caterogia Fue Actualizada Correctamente")
                    );
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existe La Categoria"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETE_Category(int id)
        {
            var _contextDB = new Application_ContextDB();
            var query = await _contextDB.Categories
                .Where(c => c.IdCategory == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdCategory == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Opcion")
                    );
                }
                else
                {
                    _contextDB.Remove(query);

                    await _contextDB.SaveChangesAsync();

                    return BadRequest(
                        MessagesJSON.MessageOK("La Categoria Fue Eliminada Correctamente")
                    );
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageOK("No Existe La Categoria"));
            }
        }
    }
}
