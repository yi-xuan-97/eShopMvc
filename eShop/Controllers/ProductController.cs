using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.ApplicationCore.ServiceInterface;
using eShop.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;
    private readonly IShoppingCartServiceAsync _shoppingCartServiceAsync;
    public ProductController(IProductRepositoryAsync repo, IShoppingCartServiceAsync srepo)
    {
        _productRepositoryAsync = repo;
        _shoppingCartServiceAsync = srepo;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var content = await _productRepositoryAsync.GetAllAsync();
        return View(content);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product obj)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _productRepositoryAsync.InsertAsync(obj);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(obj);
            }
        }

        return View(obj);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productRepositoryAsync.GetByIdAsync(id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Product obj)
    {
        await _productRepositoryAsync.DeleteAsync(obj.Id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productRepositoryAsync.GetByIdAsync(id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product obj)
    {
        try
        {
            await _productRepositoryAsync.UpdateAsync(obj);
            return RedirectToAction("Index");
        }
        catch(Exception ex)
        {
            return View(obj);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> AddCart(int id)
    {
        var result = await _productRepositoryAsync.GetByIdAsync(id);
        return View(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddToCart(int id)
    {
        if (!ModelState.IsValid)
        {
            // Return the view with the invalid model
            return RedirectToAction("Index");
        }

        int? userId = HttpContext.Session.GetInt32("uid");
        if (userId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Index", "Customer"); // Redirect to the login page
        }

        // If the user is logged in, add the product to the cart
        _shoppingCartServiceAsync.AddToCartAsync(userId.Value, id);

        // Redirect to the shopping cart index page
        return RedirectToAction("Index", "ShoppingCart");
    }
    
}