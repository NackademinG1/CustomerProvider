using CustomerProvider.Interfaces;
using CustomerProvider.Models;
using Newtonsoft.Json;
using System.Xml;

namespace CustomerProvider.Services;

public class CustomerService : ICustomerService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "customer.json");
    private readonly IFileService _fileService;
    private List<Customer> _customerList = new List<Customer>();

    public CustomerService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public ResultResponse CreateCustomer(Customer customer)
    {
        try
        {
            _customerList.Add(customer);

            if (_customerList.Any(c => c.Email == customer.Email))
                return new ResultResponse { Succeeded = true };

            _customerList.Add(customer);

            var json = JsonConvert.SerializeObject(_customerList);
            var result = _fileService.SaveToFile("", json);
            if (result)
                return new ResultResponse { Succeeded = true };

            return null!;
        }
        catch
        {
            return new ResultResponse { Succeeded = false };
        }
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _customerList;
    }

    public ResultResponse UpdateCustomer(string id)
    {
        throw new NotImplementedException();
    }

    public ResultResponse DeleteCustomer(string id)
    {
        throw new NotImplementedException();
    }
}
