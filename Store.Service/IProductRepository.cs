using Store.Models;

namespace Store.Service
{
    public interface IProductRepository
    {
        Task<List<MProducts>> GetAllProducts();

        Task<MProducts> GetProductById(int id);

        Task<MProducts> CreateProduct(MProducts products);

        Task<MProducts> UpdateProduct(MProducts products);

        Task<MProducts> DeleteProduct(int id);

        Task<List<MProducts>> SearchProduct(string input);
    }
}
