using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;

namespace eShop.Infrastructure.Repository;

public class PromotionRepositoryAsync: BaseRepositoryAsync<Promotion>, IPromotionRepositoryAsync
{
    public PromotionRepositoryAsync(eShopDbContext eb) : base(eb)
    {
    }
}