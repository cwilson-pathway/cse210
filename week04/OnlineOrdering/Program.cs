using System;

class Program
{
    static void Main(string[] args)
    {
        Order order1 = new Order();
        order1.SetCustomer("Riley Smith");
        order1.SetAddress("123 Main St", "New York City", "NY", "USA");
        order1.AddProduct("Banana", 13571, (float).5, 5);
        order1.AddProduct("Hamburger (1lb)", 78996, (float)7.50, 2);
        order1.AddProduct("Cheese Slices (12 oz)", 31567, (float)3.50, 1);

        Order order2 = new Order();
        order2.SetCustomer("Quinten Stone");
        order2.SetAddress("221B Baker St", "London", "England", "UK");
        order2.AddProduct("Oolong Tea (5oz)", 99703, 6, 2);
        order2.AddProduct("Biscuits", 25917, (float)3.5, 2);
        order2.AddProduct("Gala Apple", 13530, (float).35, 6);

        Console.Write("\nOrder 1:");
        Console.WriteLine("\nPacking Label:" + order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:" + order1.GetShippingLabel());
        Console.WriteLine("\nTotal: $" + order1.OrderTotal().ToString("0.00"));

        Console.Write("\nOrder 2:");
        Console.WriteLine("\nPacking Label:" + order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:" + order2.GetShippingLabel());
        Console.WriteLine("\nTotal: $" + order2.OrderTotal().ToString("0.00"));
    }
}