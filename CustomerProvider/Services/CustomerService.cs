using CustomerProvider.Interfaces;
using CustomerProvider.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CustomerProvider.Services;

public class CustomerService : ICustomerService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "customer.json");
    private readonly IFileService _fileService = new FileService(_filePath);
    private List<Customer> _customerList = new List<Customer>();

    public ResultResponse CreateCustomer(Customer customer)
    {
        try
        {
            GetCustomerFromFile();

            if (_customerList.Any(c => c.Email == customer.Email))
                return new ResultResponse { Succeeded = false, Message = "Email finns redan" };

            _customerList.Add(customer);

            var json = JsonConvert.SerializeObject(_customerList);
            var result = _fileService.SaveToFile("", json);
            if (result)
                return new ResultResponse { Succeeded = true, Message = "Kontot skapades korrekt" };

            return new ResultResponse { Succeeded = false, Message = "Kontot skapades men något gick fel" };
        }
        catch
        {
            return new ResultResponse { Succeeded = false };
        }
    }

    public Customer? GetOneCustomer(string email)
    {
        GetCustomerFromFile();

        try
        {
            var customer = _customerList.FirstOrDefault(c => c.Email == email);
            return customer ?? null!;
        }
        catch
        {
            return null!;
        }
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        try
        {
            GetCustomerFromFile();
            return _customerList;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public ResultResponse UpdateCustomer(string email, Customer updatedCustomer)
    {
        try
        {
            GetCustomerFromFile();
            var customer = _customerList.FirstOrDefault(c => c.Email == email);

            if (customer == null)
            {
                return new ResultResponse { Succeeded = false, Message = "Kunden hittades inte" };
            }

            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.Email = updatedCustomer.Email;

            var json = JsonConvert.SerializeObject(_customerList);
            var result = _fileService.SaveToFile("", json);

            if (result)
            {
                return new ResultResponse { Succeeded = true, Message = "Kunden uppdaterades korrekt" };
            }

            return new ResultResponse { Succeeded = false, Message = "Kunden uppdaterades men något gick fel vid sparning" };
        }
        catch (Exception ex)
        {
            return new ResultResponse { Succeeded = false, Message = $"Ett fel inträffade: {ex.Message}" };
        }
    }

    public ResultResponse DeleteCustomer(string email)
    {
        try
        {
            GetCustomerFromFile();
            var customer = GetOneCustomer(email);

            if (customer == null)
                return new ResultResponse { Succeeded = false, Message = "Email hittas inte" };

            _customerList.Remove(customer);

            var json = JsonConvert.SerializeObject(_customerList);
            var result = _fileService.SaveToFile("", json);
            if (result)
                return new ResultResponse { Succeeded = true, Message = "Kontot raderades korrekt" };

            return new ResultResponse { Succeeded = false, Message = "Kontot raderades men något gick fel" };
        }
        catch
        {
            return new ResultResponse { Succeeded = false };
        }
    }

    public void GetCustomerFromFile()
    {
        try
        {
            var content = _fileService.GetFromFile();

            if (!string.IsNullOrEmpty(content))
                _customerList = JsonConvert.DeserializeObject<List<Customer>>(content)!;
        }
        catch { }
    }
}
