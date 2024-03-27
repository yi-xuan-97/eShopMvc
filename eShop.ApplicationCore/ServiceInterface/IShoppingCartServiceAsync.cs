using eShop.ApplicationCore.Entities;

namespace eShop.ApplicationCore.ServiceInterface;

public interface IShoppingCartServiceAsync
{
    Task<IEnumerable<Product>> GetAllProductsAsync(int id);
    Task<decimal> GetTotalAsync(int id);
    void AddToCartAsync(int uid, int id);
}