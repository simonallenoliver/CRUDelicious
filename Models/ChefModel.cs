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
    [DOBValidator]
    public DateTime BirthDate { get; set; }

    public int? DishNumber { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Our navigation property to track the many Posts our user has made
    // Be sure to include the part about instantiating a new List!
    public List<Dish> AllDishes { get; set; } = new List<Dish>();


}

public class DOBValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Though we have Required as a validation, sometimes we make it here anyways
        // In which case we must first verify the value is not null before we proceed
        if (value == null)
        {
            // If it was, return the required error
            return new ValidationResult("Bday is required!");
        }
        // casting value to be a DateTime
        DateTime Birthdate = (DateTime)value;
        int Age = DateTime.Today.Year - Birthdate.Year;
        if (Birthdate >= DateTime.Today)
        {
            return new ValidationResult("Date must be in the past.");
        }
        else if (Age < 18)
        {
            return new ValidationResult("Must be 18 or older to register");
        }

        return ValidationResult.Success;

    }
}
