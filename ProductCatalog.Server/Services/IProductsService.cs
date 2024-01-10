using ProductCatalog.Server.Models;

namespace ProductCatalog.Server.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProduct(int id);
        Task<IEnumerable<Product>> CreateProduct(Product product);
        Task<Product?> UpdateProduct(Product newProduct);
        Task<bool> DeleteProduct(int id);
    }
}
