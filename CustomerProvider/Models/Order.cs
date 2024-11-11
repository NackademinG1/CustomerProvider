namespace CustomerProvider.Models;

public class Order
{
    public string ProductName { get; set; } = null!;

    public string ProductNumber { get; set; } = null!;

    public string TotalPrice { get; set; } = null!;

    public string Amount { get; set; } = null!;

    public string? Size { get; set; }

    public DateTime OrderDate { get; set; }
}

