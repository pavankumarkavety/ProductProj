using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public interface IProductRepository
    {
         void Insert(Product obj);

        Product Select(int id);
    }
}