using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Models;
using Store.Utils;

namespace Store.Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly Application_ContextDB _contextDB;

        public CompanyController(Application_ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
        }

        [HttpGet]
        public async Task<ActionResult> GET_Companies()
        {
            var query = await _contextDB.Company.ToListAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Se Encontraron Registros"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GET_Company(int id)
        {
            var query = await _contextDB.Company
                .Where(c => c.IdCompany == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Se Encontro El Registro"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> POST_Company(MCompany myCompany)
        {
            var query = await _contextDB.Company
                .Where(c => c.DNICompany == myCompany.DNICompany)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var newCompany = new MCompany
                {
                    CompanyName = myCompany.CompanyName.ToUpper(),
                    DNICompany = myCompany.DNICompany,
                    OwnerCompany = myCompany.OwnerCompany.ToUpper(),
                    DirectionCompany = myCompany.DirectionCompany.ToUpper(),
                    EmailCompany = myCompany.EmailCompany,
                    PhoneCompany = myCompany.PhoneCompany,
                    NumDocumentCompany = myCompany.NumDocumentCompany,
                    SerieOneCompany = myCompany.SerieOneCompany,
                    SerieTwoCompany = myCompany.SerieTwoCompany,
                    DataBaseName = myCompany.DataBaseName.ToUpper(),
                    TypeDocument = myCompany.TypeDocument.ToUpper(),
                    IvaCompany = myCompany.IvaCompany,
                    CoinCompany = myCompany.CoinCompany.ToUpper(),
                };

                _contextDB.Company.Add(newCompany);

                await _contextDB.SaveChangesAsync();

                return Ok("El Registro Fue Agregado Correctamente");
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("Ya Existe Un Registro"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUT_Company(MCompany myCompany)
        {
            var query = await _contextDB.Company
                .Where(c => c.IdCompany == myCompany.IdCompany)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                query.CompanyName = myCompany.CompanyName.ToUpper();
                query.DNICompany = myCompany.DNICompany;
                query.OwnerCompany = myCompany.OwnerCompany.ToUpper();
                query.DirectionCompany = myCompany.DirectionCompany.ToUpper();
                query.EmailCompany = myCompany.EmailCompany;
                query.PhoneCompany = myCompany.PhoneCompany;
                query.NumDocumentCompany = myCompany.NumDocumentCompany;
                query.SerieOneCompany = myCompany.SerieOneCompany;
                query.SerieTwoCompany = myCompany.SerieTwoCompany;
                query.DataBaseName = myCompany.DataBaseName.ToUpper();
                query.TypeDocument = myCompany.TypeDocument.ToUpper();
                query.IvaCompany = myCompany.IvaCompany;
                query.CoinCompany = myCompany.CoinCompany.ToUpper();

                await _contextDB.SaveChangesAsync();

                return BadRequest(
                    MessagesJSON.MessageOK("El Registro Fue Actualizado Correctamente")
                );
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Se Encontro El Registro"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETE_Company(int id)
        {
            var query = await _contextDB.Company
                .Where(c => c.IdCompany == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdCompany == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Realizar Esta Opeacion")
                    );
                }
                else
                {
                    _contextDB.Remove(query);

                    await _contextDB.SaveChangesAsync();

                    return Ok(MessagesJSON.MessageOK("El Registro Fue Eliminado Correctamente"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Se Encontro El Registro"));
            }
        }
    }
}
