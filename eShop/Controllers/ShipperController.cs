using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers;

public class ShipperController : Controller
{
    private readonly IShipperRepositoryAsync _shipperRepositoryAsync;

    public ShipperController(IShipperRepositoryAsync repo)
    {
        _shipperRepositoryAsync = repo;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _shipperRepositoryAsync.GetAllAsync();
        return View(result);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Shipper obj)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _shipperRepositoryAsync.InsertAsync(obj);
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
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _shipperRepositoryAsync.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Shipper obj)
    {
        try
        {
            await _shipperRepositoryAsync.UpdateAsync(obj);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
        return View(obj);
        }
    }
}