using eShop.ApplicationCore.Entities;

namespace eShop.ApplicationCore.RepositoryInterface;

public interface IShoppingCartRepositoryAsync: IRepositoryAsync<ShoppingCart>
{
    Task<ShoppingCart> GetByCustomerIdAsync(int id);
}