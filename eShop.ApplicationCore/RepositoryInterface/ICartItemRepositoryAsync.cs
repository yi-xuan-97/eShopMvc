using eShop.ApplicationCore.Entities;

namespace eShop.ApplicationCore.RepositoryInterface;

public interface ICartItemRepositoryAsync: IRepositoryAsync<CartItem>
{
    Task<IEnumerable<CartItem>> GetbyShoppingCartIdAsync(int id);
    Task<CartItem?> GetByProductIdAsync(int id, int pid);
}