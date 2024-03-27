using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers;

public class OrderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}