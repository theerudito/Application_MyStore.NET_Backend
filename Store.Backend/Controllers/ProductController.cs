using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Service;
using Store.Utils;

namespace Store.Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GET_Products()
        {
            var product = await productRepository.GetAllProducts();

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("Ocurrio un Error"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GET_Product(int id)
        {
            var product = await productRepository.GetProductById(id);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe El Producto"));
            }
        }

        [HttpGet("input")]
        public async Task<ActionResult> GET_Product_Input(string input)
        {
            var products = await productRepository.SearchProduct(input);

            if (products != null)
            {
                return Ok(products);
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Hay Datos"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> POST_Products(MProducts product)
        {
            var myproduct = await productRepository.CreateProduct(product);

            if (myproduct != null)
            {
                return Ok(MessagesJSON.MessageOK("El Producto Fue Añadido Correctamente"));
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("Ya Existe El Producto"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PUT_Products(MProducts product)
        {
            var myproduct = await productRepository.UpdateProduct(product);

            if (myproduct != null)
            {
                if (myproduct.IdProduct == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Actualizar Este Producto")
                    );
                }
                else
                {
                    return Ok(MessagesJSON.MessageOK("El Producto Fue Actualizado Correctamente"));
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe El Producto"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DELETE_Products(int id)
        {
            var product = await productRepository.DeleteProduct(id);

            if (product != null)
            {
                if (product.IdProduct == 1)
                {
                    return BadRequest(
                        MessagesJSON.MessageError("No Se Puede Eliminar Este Producto")
                    );
                }
                else
                {
                    if (product.Status == true)
                    {
                        return Ok(MessagesJSON.MessageOK("El Producto fue Activado"));
                    }
                    else
                    {
                        return Ok(MessagesJSON.MessageOK("El Producto fue Desactivado"));
                    }
                }
            }
            else
            {
                return BadRequest(MessagesJSON.MessageError("No Existe El Producto"));
            }
        }
    }
}
