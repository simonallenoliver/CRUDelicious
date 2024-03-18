using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public ChefController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

// this displays our add new chef page and form
    [HttpGet("chefs/new")]
    public ViewResult NewChef() 
    {
        return View();
    }

    // this is the post route for our form
[HttpPost("chefs/create")]
public IActionResult AddChef(Chef newChef)
{
    // validations checked
    if (!ModelState.IsValid)
    {
        return View ("NewChef");
    }
// if the validations go through, then we add our form data to the db
// in our context file, it knows to associate our Dish model with the Dishes table in our db
    _context.Add(newChef);
    // ALWAYS SAVE CHANGES
    _context.SaveChanges();
    // then we redirect to our index page, in our Home controller
    return RedirectToAction("AllChefs");

}

// this is our display page for all the dishes in our db
    [HttpGet("chefs")]
    public ViewResult AllChefs()
    {
        List<Chef> ChefsFromDB = _context.Chefs.Include(c => c.AllDishes).ToList();
        
        return View("AllChefs", ChefsFromDB);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}