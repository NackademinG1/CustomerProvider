using CustomerProvider.Factories;
using CustomerProvider.Interfaces;
using CustomerProvider.Models;
using CustomerProvider.Services;

namespace CustomerProvider_Tests;

public class CustomerProvider_Tests
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
    public void DeleteCustomer_ShouldDeleteCustomerFromDatabasAndReturnSucceeded()
    {
        CustomerService customerService = new CustomerService();
        var customer = new Customer { FirstName = "Cecilia", LastName = "Sporrong", Email = "cs@domain.com", Id = "Cs123" };
        customerService.CreateCustomer(customer);

        var response = customerService.DeleteCustomer(customer.Email);

        Assert.True(response.Succeeded);
    }

    #endregion

    #region BaseResponseResult

    [Fact]
    public void Success_ShouldReturnSuccessAndStatusCode200()
    {
        var result = BaseResultResponseFactory.Success();

        Assert.IsAssignableFrom<IBaseResultResponse>(result);
        Assert.True(result.Succeeded);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void Failed_ShouldReturnSuccessAndStatusCode400()
    {
        var result = BaseResultResponseFactory.Failure();

        Assert.IsAssignableFrom<IBaseResultResponse>(result);
        Assert.False(result.Succeeded);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void Exists_ShouldReturnSuccessAndStatusCode409()
    {
        var result = BaseResultResponseFactory.Exists();

        Assert.IsAssignableFrom<IBaseResultResponse>(result);
        Assert.False(result.Succeeded);
        Assert.Equal(409, result.StatusCode);
    }

    [Fact]
    public void NotFound_ShouldReturnSuccessAndStatusCode404()
    {
        var result = BaseResultResponseFactory.NotFound();

        Assert.IsAssignableFrom<IBaseResultResponse>(result);
        Assert.False(result.Succeeded);
        Assert.Equal(404, result.StatusCode);
    }

    #endregion

    #region TrackingCode 
    //Genereted together with chatGPT
    [Fact]
    public void OrderFactory_ShouldGenerateUniqueTrackingCode()
    {
        var order1 = new Order { ProductName = "Produkt1", ProductNumber = "123" };
        var order2 = new Order { ProductName = "Produkt2", ProductNumber = "456" };

        var createdOrder1 = OrderFactory.Create(order1);
        var createdOrder2 = OrderFactory.Create(order2);

        Assert.NotEqual(createdOrder1.TrackingCode, createdOrder2.TrackingCode);
        Assert.NotNull(createdOrder1.TrackingCode);
        Assert.NotNull(createdOrder2.TrackingCode);
    }

    #endregion

}
