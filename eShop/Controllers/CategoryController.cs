using eShop.ApplicationCore.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers;

public class CategoryController : Controller
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;
    private readonly ICategoryRepositoryAsync _categoryRepositoryAsync;

    public CategoryController(IProductRepositoryAsync prepo, ICategoryRepositoryAsync crepo)
    {
        _productRepositoryAsync = prepo;
        _categoryRepositoryAsync = crepo;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _categoryRepositoryAsync.GetAllAsync();
        return View(result);
    }
}