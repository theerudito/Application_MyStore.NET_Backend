using Microsoft.AspNetCore.Mvc;

namespace Store.Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GET_CART()
        {
            return Ok(new { message = "Hola que tal como vas" });
        }
    }
}
