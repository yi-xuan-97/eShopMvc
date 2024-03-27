using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using eShop.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers;

public class CustomerController : Controller
{
    protected readonly ICustomerRepositoryAsync CustomerRepositoryAsync;
    
    public CustomerController(ICustomerRepositoryAsync repo)
    {
        CustomerRepositoryAsync = repo;
    }
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(int id)
    {
        HttpContext.Session.SetInt32("uid",id);
        return RedirectToAction("Display", new { id = id });
    }

    public async Task<IActionResult> Display(int id)
    {
        var result = await CustomerRepositoryAsync.GetByIdAsync(id);
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await CustomerRepositoryAsync.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Customer obj)
    {
        try
        {
            await CustomerRepositoryAsync.UpdateAsync(obj);
            return RedirectToAction("Display", new { id = obj.Id });
        }
        catch (Exception ex)
        {
            return View("Index");
        }
    }
}