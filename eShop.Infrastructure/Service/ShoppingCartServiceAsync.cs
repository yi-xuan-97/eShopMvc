using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.ApplicationCore.ServiceInterface;
using eShop.Infrastructure.Data;
using eShop.Infrastructure.Repository;

namespace eShop.Infrastructure.Service;

public class ShoppingCartServiceAsync: IShoppingCartServiceAsync
{
    private readonly IShoppingCartRepositoryAsync _shoppingCartRepositoryAsync;
    private readonly ICartItemRepositoryAsync _cartItemRepositoryAsync;
    private readonly IProductRepositoryAsync _productRepositoryAsync;
    public ShoppingCartServiceAsync(IShoppingCartRepositoryAsync repo, ICartItemRepositoryAsync crepo,
        IProductRepositoryAsync prepo)
    {
        _shoppingCartRepositoryAsync = repo;
        _cartItemRepositoryAsync = crepo;
        _productRepositoryAsync = prepo;
    }
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync(int id)
    {
        var shoppingCart = await _shoppingCartRepositoryAsync.GetByCustomerIdAsync(id);
        var result = await _cartItemRepositoryAsync.GetbyShoppingCartIdAsync(shoppingCart.Id);
        List<Product> list = new List<Product>();
        foreach (var item in result)
        {
            list.Add(await _productRepositoryAsync.GetByIdAsync(item.ProductId));
        }
        return list as IEnumerable<Product>;
    }

    public async Task<decimal> GetTotalAsync(int id)
    {
        var shoppingCart = _shoppingCartRepositoryAsync.GetByCustomerIdAsync(id).Id;
        var result = await _cartItemRepositoryAsync.GetbyShoppingCartIdAsync(shoppingCart);
        List<Product> list = new List<Product>();
        foreach (var item in result)
        {
            list.Add(await _productRepositoryAsync.GetByIdAsync(item.ProductId));
        }

        decimal num = 0;
        foreach (var item in list)
        {
            num += item.Price;
        }

        return num;
    }

    public async void AddToCartAsync(int uid, int productId)
    {
        // Retrieve the user's shopping cart
        var shoppingCart = await _shoppingCartRepositoryAsync.GetByCustomerIdAsync(uid);

        // Retrieve the cart item for the given product and shopping cart
        var cartItem = await _cartItemRepositoryAsync.GetByProductIdAsync(shoppingCart.Id, productId);

        if (cartItem == null)
        {
            // If the cart item doesn't exist, create a new one
            cartItem = new CartItem
            {
                ProductId = productId,
                ShoppingCartId = shoppingCart.Id,
                Quantity = 1 // Set initial quantity to 1
            };
            await _cartItemRepositoryAsync.InsertAsync(cartItem);
        }
        else
        {
            // If the cart item exists, increment its quantity
            cartItem.Quantity++; // Increment the quantity
            await _cartItemRepositoryAsync.UpdateAsync(cartItem);
        }
    }
}