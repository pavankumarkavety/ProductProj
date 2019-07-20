using ProductsAPI.Application.Models;

namespace ProductsAPI.Application.Services
{
    public interface IProductRepository
    {
         void Insert(Product obj);

        Product Select(int id);
    }
}