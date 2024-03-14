using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using System.Globalization;

namespace CRUDelicious.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("dishes/new")]
    public ViewResult NewDish() 
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


