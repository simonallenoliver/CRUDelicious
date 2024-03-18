using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

// this displays our create new dish page and form
    [HttpGet("dishes/new")]
    public ViewResult NewDish() 
    {
        List<Chef> ChefsFromDB = _context.Chefs.OrderByDescending(c => c.CreatedAt).ToList();
        return View("NewDish", ChefsFromDB);
    }

// this is the post route for our form
[HttpPost("dishes/create")]
public IActionResult CreateDish(Dish newDish)
{
    // validations checked
    if (!ModelState.IsValid)
    {
        return View ("NewDish");
    }
// if the validations go through, then we add our form data to the db
// in our context file, it knows to associate our Dish model with the Dishes table in our db
    _context.Add(newDish);
    // ALWAYS SAVE CHANGES
    _context.SaveChanges();
    // then we redirect to our index page, in our Home controller
    return RedirectToAction("AllDishes");

}

// this is our display page for all the dishes in our db
    [HttpGet("dishes")]
    public ViewResult AllDishes()
    {
        List<Dish> DishesFromDB = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        
        return View("AllDishes", DishesFromDB);
    }

    // view one page
    [HttpGet("dishes/{dishId}")]
    public IActionResult ViewDish(int dishId)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if ( OneDish == null)
        {
            return RedirectToAction("AllDishes");
        }
        return View("OneDish", OneDish);
    }


    // edit page
    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if(OneDish == null)
        {
            return RedirectToAction("AllDishes");
        }
        return View("EditDish", OneDish);
    }

    // edit Post route
    [HttpPost("dishes/{dishId}/edit")]
    public IActionResult UpdateDish(int dishId, Dish newDish)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (ModelState.IsValid)
        {
            OneDish.Name = newDish.Name;
            OneDish.Chef = newDish.Chef;
            OneDish.Calories = newDish.Calories;
            OneDish.Tastiness = newDish.Tastiness;
            OneDish.Description = newDish.Description;

            OneDish.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("AllDishes");

        } 
        else
        {
            return View("EditDish", newDish);
        }
    }

    // delete route
    [HttpPost("dishes/{dishId}/delete")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? OneDish = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if(OneDish != null)
        {
            _context.Dishes.Remove(OneDish);
            _context.SaveChanges();
        }
        return RedirectToAction("AllDishes");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


