using System.ComponentModel.DataAnnotations;

namespace CustomerProvider.Models;

public class Customer
{
    [Required(ErrorMessage = "Du måste fylla i ditt förnamn")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Du måste fylla i ditt efternamn")]
    public string LastName { get; set;} = null!;

    [Required(ErrorMessage = "Du måste fylla i din email")]
    public string Email { get; set; } = null!;
}
