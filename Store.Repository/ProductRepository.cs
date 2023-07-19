using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Models;
using Store.Service;

namespace Store.Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task<MProducts> CreateProduct(MProducts products)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Product
                .Where(p => p.CodeProduct == products.CodeProduct)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                return null;
            }
            else
            {
                _contextDB.Product.Add(products);

                await _contextDB.SaveChangesAsync();

                return products;
            }
        }

        public async Task<MProducts> DeleteProduct(int id)
        {
            var _contextDB = new Application_ContextDB();

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
            var _contextDB = new Application_ContextDB();

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
            var _contextDB = new Application_ContextDB();
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

        public async Task<MProducts> UpdateProduct(MProducts products)
        {
            var _contextDB = new Application_ContextDB();

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
                    query.CodeProduct = products.Brand;
                    query.NameProduct = products.NameProduct;
                    query.Brand = products.Brand;
                    query.Category = products.Category;
                    query.Description = products.Description;
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
