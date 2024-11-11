using CustomerProvider.Models;
using System.Net.Http.Headers;

namespace CustomerProvider.Factories;

public static class OrderFactory
{
    public static Order Create(Order order)
    {
        var productOrder = new Order()
        {
            ProductName = order.ProductName,
            ProductNumber = order.ProductNumber,
            TotalPrice = order.TotalPrice,
            Amount = order.Amount,
            Size = order.Size
        };

         return productOrder;
    }
}
