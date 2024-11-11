using System.ComponentModel.DataAnnotations;

namespace CustomerProvider.Models;

public class CreateCustomer : Customer
{
    [Required(ErrorMessage = "Du måste fylla ett lösenord")]
    public string Password { get; set; } = null!;
}