using CustomerProvider.Models;
using CustomerProvider.Services;

namespace CustomerProvider_Tests;

public class CustomerService_Tests
{
    #region AddToList

    [Fact]
    public void CreateCustomer_ShouldAddNewCustomerToListAndReturnSucceeded()
    {
        // Arrange
        Customer customer = new Customer { FirstName = "Cecilia", LastName = "Sporrong", Email = "cs@domain.com" };
        CustomerService customerService = new CustomerService();

        // Act
        var result = customerService.CreateCustomer(customer);
        var customerList = customerService.GetAllCustomers();

        // Assert
        Assert.True(result.Succeeded);
        Assert.Single(customerList);
    }

    #endregion

    #region Delete
    [Fact]
    public void DeleteCustomer_ShouldDeleteCustomerFromDatabas()
    {

    }

    #endregion

}
