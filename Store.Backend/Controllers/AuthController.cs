using Microsoft.AspNetCore.Mvc;

namespace Store.Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //[HttpPost("register")]
        //public async Task<ActionResult> POSTRegister([FromBody] MAuth auth)
        //{
        //    var _contextDB = new Application_ContextDB();

        //    var searchUser = await _contextDB.Auth.Where(user => user.UserName == auth.UserName).FirstOrDefaultAsync();

        //    if (searchUser == null)
        //    {
        //        encryp password
        //        auth.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);

        //        add new User
        //        _contextDB.Auth.Add(auth);
        //        await _contextDB.SaveChangesAsync();
        //        return Ok("Registrado");
        //    }
        //    else
        //    {
        //        return BadRequest("Ya Existe");
        //    }
        //}

        //[HttpPost("login")]
        //public async Task<ActionResult> POSTLogin([FromBody] MAuthDTO auth)
        //{
        //    var _contextDB = new Application_ContextDB();

        //    var query = await _contextDB.Auth.Where(user => user.UserName == auth.UserName).FirstOrDefaultAsync();

        //    if (query == null)
        //    {
        //        return BadRequest(new { message = "User does not exist" });
        //    }

        //    compare password
        //    if (!BCrypt.Net.BCrypt.Verify(auth.Password, query.Password))
        //    {
        //        return BadRequest(new { message = "Password or email is wrong" });
        //    }

        //    return Ok("Logiado");
        //}

        //[HttpGet]
        //public async Task<ActionResult> GETUsers()
        //{
        //    var _contextDB = new Application_ContextDB();

        //    var query = await _contextDB.Auth.ToListAsync();
        //    return Ok(query);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult> GETUser(int id)
        //{
        //    var _contextDB = new Application_ContextDB();

        //    var query = await _contextDB.Auth.Where(auth => auth.IdAuth == id).FirstOrDefaultAsync();

        //    if (query != null)
        //    {
        //        return Ok(query);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> PUTUser([FromBody] MAuth auth)
        //{
        //    var _contextDB = new Application_ContextDB();

        //    var query = await _contextDB.Auth.Where(user => user.IdAuth == auth.IdAuth).FirstOrDefaultAsync();

        //    if (query != null)
        //    {
        //        if (query.IdAuth == 1)
        //        {
        //            return BadRequest("No Se Puede Realizar esta Accion");
        //        }
        //        else
        //        {
        //            query.User = auth.User;
        //            query.UserName = auth.UserName;
        //            query.Email = auth.Email;
        //            query.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
        //            query.Phone = auth.Phone;
        //            query.Direction = auth.Direction;
        //            query.Role = auth.Role;
        //            query.Status = auth.Status;

        //            await _contextDB.SaveChangesAsync();
        //            return Ok("Actualizado");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Error");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DELETEUser(int id)
        //{
        //    var _contextDB = new Application_ContextDB();

        //    var query = await _contextDB.Auth.Where(user => user.IdAuth == id).FirstOrDefaultAsync();

        //    if (query != null)
        //    {
        //        if (query.IdAuth == 1)
        //        {
        //            return BadRequest("No Se Puede Realizar esta Accion");
        //        }
        //        else
        //        {
        //            if (query.Status == false)
        //            {
        //                query.Status = true;
        //                await _contextDB.SaveChangesAsync();
        //                return Ok("El Usuario Se Ha Activado");
        //            }
        //            else
        //            {
        //                query.Status = false;
        //                await _contextDB.SaveChangesAsync();
        //                return Ok("El Usuario Se Ha Desactivado");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Error");
        //    }
        //}
    }
}