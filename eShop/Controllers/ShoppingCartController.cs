using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.ApplicationCore.ServiceInterface;
using eShop.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers;

public class ShoppingCartController : Controller
{
    private IShoppingCartServiceAsync _shoppingCartServiceAsync;
    public ShoppingCartController(IShoppingCartServiceAsync repo)
    {
        _shoppingCartServiceAsync = repo;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        if ( HttpContext.Session.GetInt32("uid") != null)
        {
            var result = await _shoppingCartServiceAsync.GetAllProductsAsync((int)HttpContext.Session.GetInt32("uid"));
            return View(result);
        }

        return View();
    }

    public async Task<IActionResult> CheckOut()
    {
        if (HttpContext.Session.GetInt32("uid") != null && _shoppingCartServiceAsync != null)
        {
            var result = await _shoppingCartServiceAsync.GetTotalAsync((int)HttpContext.Session.GetInt32("uid"));
            return View(result);
        }
        
        return View(0);
    }
}