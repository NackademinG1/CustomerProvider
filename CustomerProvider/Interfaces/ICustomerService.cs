using CustomerProvider.Models;

namespace CustomerProvider.Interfaces;

public interface ICustomerService
{
    public ResultResponse CreateCustomer(Customer customer);

    public IEnumerable<Customer> GetAllCustomers();

    public ResultResponse UpdateCustomer(string id);

    public ResultResponse DeleteCustomer(string id);

}
