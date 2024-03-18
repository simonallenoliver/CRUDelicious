#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Display(Name = "First Name: ")]
    [Required(ErrorMessage = "Hey this field is required!")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name: ")]
    [Required(ErrorMessage = "Hey this field is required!")]
    public string? LastName { get; set; }
    
    [Display(Name = "Birthday: ")]
    [Required(ErrorMessage = "Hey this field is required!")]
    public DateTime BirthDate { get; set; }

    public int? DishNumber { get; set; } = 0;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Our navigation property to track the many Posts our user has made
    // Be sure to include the part about instantiating a new List!
    public List<Dish> AllDishes { get; set; } = new List<Dish>();


}