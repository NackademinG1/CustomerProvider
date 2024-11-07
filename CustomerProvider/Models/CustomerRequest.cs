namespace CustomerProvider.Models;

public class CustomerRequest : Customer
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
