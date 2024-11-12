using CustomerProvider.Models;

namespace CustomerProvider.Interfaces;

public interface ICustomerService
{
    public BaseResultResponse CreateCustomer(Customer customer);

    public IEnumerable<Customer> GetAllCustomers();

    public Customer? GetOneCustomer(string email);

    public BaseResultResponse UpdateCustomer(string email, Customer updatedCustomer);

    public BaseResultResponse DeleteCustomer(string email);

    public void GetCustomerFromFile();
}
