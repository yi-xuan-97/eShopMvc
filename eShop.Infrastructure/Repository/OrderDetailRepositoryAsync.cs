using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;

namespace eShop.Infrastructure.Repository;

public class OrderDetailRepositoryAsync: BaseRepositoryAsync<OrderDetail>, IOrderDetailRepositoryAsync
{
    public OrderDetailRepositoryAsync(eShopDbContext eb) : base(eb)
    {
    }
}