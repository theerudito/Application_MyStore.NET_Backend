using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Models;
using Store.Service;

namespace Store.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Application_ContextDB _contextDB;

        public ProductRepository(Application_ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
        }

        public async Task<MProducts> CreateProduct(MProducts products)
        {
            var query = await _contextDB.Product
                .Where(p => p.CodeProduct == products.CodeProduct.ToUpper())
                .FirstOrDefaultAsync();

            if (query != null)
            {
                return null;
            }
            else
            {
                var newProduct = new MProducts
                {
                    CodeProduct = products.CodeProduct,
                    NameProduct = products.NameProduct.ToUpper(),
                    Brand = products.Brand.ToUpper(),
                    Category = products.Category.ToUpper(),
                    Description = products.Description.ToUpper(),
                    PriceUnitary = products.PriceUnitary,
                    PriceTotal = products.PriceTotal,
                    Quantity = products.Quantity,
                    Status = products.Status,
                    Iva = products.Iva,
                };

                _contextDB.Product.Add(newProduct);

                await _contextDB.SaveChangesAsync();

                return products;
            }
        }

        public async Task<MProducts> DeleteProduct(int id)
        {
            var query = await _contextDB.Product
                .Where(p => p.IdProduct == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdProduct == 1)
                {
                    return new MProducts { IdProduct = 1 };
                }
                else
                {
                    if (query.Status == true)
                    {
                        query.Status = false;
                        await _contextDB.SaveChangesAsync();
                        return query;
                    }
                    else
                    {
                        query.Status = true;
                        await _contextDB.SaveChangesAsync();
                        return query;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<List<MProducts>> GetAllProducts()
        {
            var query = await _contextDB.Product.ToListAsync();

            if (query != null)
            {
                return query;
            }
            else
            {
                return null;
            }
        }

        public async Task<MProducts> GetProductById(int id)
        {
            var query = await _contextDB.Product
                .Where(p => p.IdProduct == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                return query;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<MProducts>> SearchProduct(string input)
        {
            var query = await _contextDB.Product
                .Where(
                    p =>
                        p.CodeProduct.Contains(input.ToUpper())
                        || p.Description.Contains(input.ToUpper())
                        || p.Brand.Contains(input.ToUpper())
                        || p.Category.Contains(input.ToUpper())
                )
                .ToListAsync();

            if (query != null)
            {
                return query;
            }
            else
            {
                return null;
            }
        }

        public async Task<MProducts> UpdateProduct(MProducts products)
        {
            var query = await _contextDB.Product
                .Where(p => p.IdProduct == products.IdProduct)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdProduct == 1)
                {
                    return new MProducts { IdProduct = 1 };
                }
                else
                {
                    query.CodeProduct = products.CodeProduct;
                    query.NameProduct = products.NameProduct.ToUpper();
                    query.Brand = products.Brand.ToUpper();
                    query.Category = products.Category.ToUpper();
                    query.Description = products.Description.ToUpper();
                    query.Iva = products.Iva;
                    query.PriceUnitary = products.PriceUnitary;
                    query.PriceTotal = products.PriceTotal;
                    query.Status = products.Status;
                    query.Quantity = products.Quantity;

                    await _contextDB.SaveChangesAsync();

                    return products;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
