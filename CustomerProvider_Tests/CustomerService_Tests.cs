using CustomerProvider.Interfaces;
using CustomerProvider.Models;
using CustomerProvider.Services;
using Moq;

namespace CustomerProvider_Tests;

public class CustomerService_Tests
{

    [Fact]
    public void CreateCustomer_ShouldAddNewCustomerToListAndReturnSucceeded()
    {
        // Arrange
        Mock<IFileService> fileServiceMock = new Mock<IFileService>();
        fileServiceMock.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

        CustomerService customerService = new CustomerService(fileServiceMock.Object);
        Customer customer = new Customer { FirstName = "Cecilia", LastName = "Sporrong", Email = "cs@domain.com" };

        // Act
        var result = customerService.CreateCustomer(customer);
        var customerList = customerService.GetAllCustomers();

        // Assert
        Assert.True(result.Succeeded);
        Assert.Single(customerList);
    }
}
