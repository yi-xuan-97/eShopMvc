using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository;

public class ShipperRepositoryAsync: BaseRepositoryAsync<Shipper>, IShipperRepositoryAsync
{
    public ShipperRepositoryAsync(eShopDbContext eb) : base(eb)
    {
    }
    
}