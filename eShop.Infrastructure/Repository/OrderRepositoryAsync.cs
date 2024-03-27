using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;

namespace eShop.Infrastructure.Repository;

public class OrderRepositoryAsync: BaseRepositoryAsync<Order>, IOrderRepositoryAsync
{
    public OrderRepositoryAsync(eShopDbContext eb) : base(eb)
    {
    }
}