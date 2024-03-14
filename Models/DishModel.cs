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

    [Display(Name = "Chef's Name: ")]
    [Required(ErrorMessage = "Hey this field is required!")]
    public string? Chef { get; set; }
    
    public int Tastiness { get; set; }
    [Required(ErrorMessage = "Hey this field is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be at least 1")]
    public int? Calories { get; set; }

    [Required(ErrorMessage = "Hey this field is required!")]
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


}
