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
        private readonly Application_ContextDB _contextDB;

        public CategoryController(Application_ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
        }

        [HttpGet]
        public async Task<ActionResult> GET_Categories()
        {
            var query = await _contextDB.Categories.ToListAsync();

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
        public async Task<ActionResult> GET_Category(int id)
        {
            var query = await _contextDB.Categories
                .Where(c => c.IdCategory == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe La Categoria"));
            }
        }

        [HttpGet("category")]
        public async Task<ActionResult> GET_Category_Name(string category)
        {
            var query = await _contextDB.Categories
                .Where(c => c.Category.Contains(category.ToUpper()))
                .ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe La Categoria"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> POST_Category(MCategory mycategory)
        {
            var query = await _contextDB.Categories
                .Where(c => c.Category == mycategory.Category.ToUpper())
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var newCategory = new MCategory { Category = mycategory.Category.ToUpper() };

                _contextDB.Categories.Add(newCategory);

                await _contextDB.SaveChangesAsync();

                return Ok(MessagesJSON.MessageOK("La Categoria Fue Agregada Correctamente"));
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe La Categoria"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUT_Category(MCategory mycategory)
        {
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
                    query.Category = mycategory.Category.ToUpper();

                    await _contextDB.SaveChangesAsync();

                    return BadRequest(
                        MessagesJSON.MessageOK("La Caterogia Fue Actualizada Correctamente")
                    );
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe La Categoria"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETE_Category(int id)
        {
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
                return BadRequest(MessagesJSON.MessageError("No Existe La Categoria"));
            }
        }
    }
}
