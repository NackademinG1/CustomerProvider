using CustomerProvider.Models;

namespace CustomerProvider.Factories;

public static class CustomerFactory
{
    public static CustomerBacklogg Create(Customer customerInfo)
    {
        try
        {
            var customer = new Customer()
            {
                FirstName = customerInfo.FirstName,
                LastName = customerInfo.LastName,
                Email = customerInfo.Email,
                Id = customerInfo.Id + Guid.NewGuid().ToString()
            };

            return customer;
        }
        catch
        {
            return null!;
        }
    }
}
