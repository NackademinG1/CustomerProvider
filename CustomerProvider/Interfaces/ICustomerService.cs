using CustomerProvider.Models;

namespace CustomerProvider.Interfaces;

public interface ICustomerService
{
    public ResultResponse CreateCustomer(Customer customer);

    public IEnumerable<Customer> GetAllCustomers();

    public Customer? GetOneCustomer(string email);

    public ResultResponse UpdateCustomer(string email, Customer updatedCustomer);

    public ResultResponse DeleteCustomer(string email);

    public void GetCustomerFromFile();
}
