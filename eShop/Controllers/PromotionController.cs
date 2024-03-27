using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers;

public class PromotionController : Controller
{
    private readonly IPromotionRepositoryAsync _promotionRepositoryAsync;

    public PromotionController(IPromotionRepositoryAsync repo)
    {
        _promotionRepositoryAsync = repo;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var allPromotions = await _promotionRepositoryAsync.GetAllAsync();

        ViewBag.availablePromotion = allPromotions
            .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
            .ToList();

        ViewBag.nonavailablePromotion = allPromotions
            .Where(x => x.StartDate > DateTime.Now)
            .ToList();
        
        return View(ViewBag);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Promotion obj)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _promotionRepositoryAsync.InsertAsync(obj);
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
        var result = await _promotionRepositoryAsync.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Promotion obj)
    {
        try
        {
            await _promotionRepositoryAsync.UpdateAsync(obj);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View(obj);
        }
    }
}