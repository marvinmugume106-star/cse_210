using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var order1 = CreateOrder(
            "1001",
            "John Doe",
            new Address("123 Elm Street", "Springfield", "IL", "USA"),
            new[]
            {
                new Product("Laptop", "P1001", 799.99m, 1),
                new Product("Wireless Mouse", "P1002", 24.99m, 2),
                new Product("USB Cable", "P1003", 5.99m, 3)
            });

        var order2 = CreateOrder(
            "1002",
            "Sara Lee",
            new Address("456 Oak Avenue", "Seattle", "WA", "USA"),
            new[]
            {
                new Product("Desk Lamp", "P1004", 19.99m, 2),
                new Product("Notebook", "P1005", 3.99m, 5),
                new Product("Pen Set", "P1006", 9.99m, 1)
            });

        var orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            order.DisplayOrderDetails();
            Console.WriteLine();
        }
    }

    private static Order CreateOrder(string orderNumber, string customerName, Address address, Product[] products)
    {
        var customer = new Customer(customerName, address);
        var order = new Order(orderNumber, customer);

        foreach (var product in products)
        {
            order.AddProduct(product);
        }

        return order;
    }
}
