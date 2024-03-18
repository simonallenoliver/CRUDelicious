#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Display(Name = "Name of Dish: ")]
    [Required(ErrorMessage = "Hey this field is required!")]
    public string? Name { get; set; }
    

    public int Tastiness { get; set; }
    [Required(ErrorMessage = "Hey this field is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be at least 1")]
    public int? Calories { get; set; }

    [Required(ErrorMessage = "Hey this field is required!")]
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId { get; set; }

    // Our navigation property to track which Chef made this Post
    // It is VERY important to include the ? on the datatype or this won't work!
    public Chef? Creator { get; set; }
}
