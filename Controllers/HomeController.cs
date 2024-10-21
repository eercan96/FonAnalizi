using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FonAnalizi.Models;
using FonAnalizi.Data;
using Microsoft.EntityFrameworkCore;

namespace FonAnalizi.Controllers;

public class HomeController : Controller
{
  //  private readonly ILogger<HomeController> _logger;

   // public HomeController(ILogger<HomeController> logger)
   // {
   //     _logger = logger;
   // }

   private readonly DataContext _context;

    public HomeController(DataContext context)
    {
        _context = context;
    }


    [Route("")]
    [Route("Home/Index")]
    public async Task<IActionResult> Index(string sortOrder)
{
    ViewBag.PriceSortParm = sortOrder == "price_asc" ? "price_desc" : "price_asc";
    ViewBag.OneDayChangeSortParm = sortOrder == "oneDayChange_asc" ? "oneDayChange_desc" : "oneDayChange_asc";
    ViewBag.OneWeekChangeSortParm = sortOrder == "oneWeekChange_asc" ? "oneWeekChange_desc" : "oneWeekChange_asc";
    ViewBag.OneMonthChangeSortParm = sortOrder == "oneMonthChange_asc" ? "oneMonthChange_desc" : "oneMonthChange_asc";
    ViewBag.ThreeMonthChangeSortParm = sortOrder == "threeMonthChange_asc" ? "threeMonthChange_desc" : "threeMonthChange_asc";
    ViewBag.SixMonthChangeSortParm = sortOrder == "sixMonthChange_asc" ? "sixMonthChange_desc" : "sixMonthChange_asc";
    ViewBag.OneYearChangeSortParm = sortOrder == "oneYearChange_asc" ? "oneYearChange_desc" : "oneYearChange_asc";
    ViewBag.ThreeYearChangeSortParm = sortOrder == "threeYearChange_asc" ? "threeYearChange_desc" : "threeYearChange_asc";
    ViewBag.FiveYearChangeSortParm = sortOrder == "fiveYearChange_asc" ? "fiveYearChange_desc" : "fiveYearChange_asc";

    var fons = from f in _context.Fons
               select f;

    // Sıralama işlemi
    switch (sortOrder)
    {
        case "price_desc":
            fons = fons.OrderByDescending(f => f.Price);
            break;
        case "price_asc":
            fons = fons.OrderBy(f => f.Price);
            break;
        case "oneDayChange_asc":
            fons = fons.OrderBy(f => f.OneDayChange);
            break;
        case "oneDayChange_desc":
            fons = fons.OrderByDescending(f => f.OneDayChange);
            break;
        case "oneWeekChange_asc":
            fons = fons.OrderBy(f => f.OneWeekChange);
            break;
        case "oneWeekChange_desc":
            fons = fons.OrderByDescending(f => f.OneWeekChange);
            break;
        case "oneMonthChange_asc":
            fons = fons.OrderBy(f => f.OneMonthChange);
            break;
        case "oneMonthChange_desc":
            fons = fons.OrderByDescending(f => f.OneMonthChange);
            break;
        case "threeMonthChange_asc":
            fons = fons.OrderBy(f => f.ThreeMonthChange);
            break;
        case "threeMonthChange_desc":
            fons = fons.OrderByDescending(f => f.ThreeMonthChange);
            break;
        case "sixMonthChange_asc":
            fons = fons.OrderBy(f => f.SixMonthChange);
            break;
        case "sixMonthChange_desc":
            fons = fons.OrderByDescending(f => f.SixMonthChange);
            break;
        case "oneYearChange_asc":
            fons = fons.OrderBy(f => f.OneYearChange);
            break;
        case "oneYearChange_desc":
            fons = fons.OrderByDescending(f => f.OneYearChange);
            break;
        case "threeYearChange_asc":
            fons = fons.OrderBy(f => f.ThreeYearChange);
            break;
        case "threeYearChange_desc":
            fons = fons.OrderByDescending(f => f.ThreeYearChange);
            break;
        case "fiveYearChange_asc":
            fons = fons.OrderBy(f => f.FiveYearChange);
            break;
        case "fiveYearChange_desc":
            fons = fons.OrderByDescending(f => f.FiveYearChange);
            break;
        default:
            fons = fons.OrderBy(f => f.FonName);
            break;
    }

    return View(await fons.ToListAsync());
}

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }



    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
   // public IActionResult Error()
   // {
//        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
   // }
}
