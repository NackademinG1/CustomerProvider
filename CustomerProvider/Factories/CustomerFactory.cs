using CustomerProvider.Models;

namespace CustomerProvider.Factories;

public class CustomerFactory
{
    public static Customer Create(CustomerRequest customerRequest)
    {
        try
        {
            var customer = new Customer()
            {
                FirstName = customerRequest.FirstName,
                LastName = customerRequest.LastName,
                Email = customerRequest.Email,
            };
            return customer;
        }
        catch
        {
            return null!;
        }
    }
}
