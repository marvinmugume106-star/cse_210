using System;
using System.Collections.Generic;

class Order
{
    private string _orderNumber;
    private Customer _customer;
    private readonly List<Product> _products = new List<Product>();

    public Order(string orderNumber, Customer customer)
    {
        _orderNumber = orderNumber;
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        if (product == null || product.Quantity < 1)
        {
            return;
        }

        _products.Add(product);
    }

    public decimal GetShippingCost()
    {
        return _customer.LivesInUSA() ? 5m : 35m;
    }

    public decimal GetTotalCost()
    {
        decimal total = 0m;
        foreach (var product in _products)
        {
            total += product.TotalCost;
        }
        return total + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        var label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.Name} ({product.ProductId})\n";
        }
        return label.TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nCustomer: {_customer.Name}\n{_customer.Address.GetFormattedAddress()}";
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine($"Order: {_orderNumber}");
        Console.WriteLine("---------------------------");
        Console.WriteLine(GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Shipping Cost: {GetShippingCost():C}");
        Console.WriteLine($"Total Cost: {GetTotalCost():C}");
    }
}
