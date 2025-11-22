using System.Data.SqlTypes;

class Order 
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public float OrderTotal()
    {
        // Calculates total
        float subTotal = 0;
        foreach (Product product in _products)
        {
            subTotal += product.SubtotalOfQuantity();
        }
        
        // If IsUSA, shipping cost is $5, else shipping cost is $35.
        if (_customer.IsUSA())
        {
            subTotal += 5;
        }
        else
        {
            subTotal += 35;
        }

        return subTotal;
    }

    public string GetPackingLabel()
    {
        // Generates list of products
        string packingString = "";
        foreach (Product product in _products)
        {
            packingString += product.GetPackingInfo();
        }

        return packingString;
    }

    public string GetShippingLabel()
    {
        // Generates shipping label
        return _customer.GetDisplayText();
    }

    public void AddProduct(string name, int id, float price, int quantity)
    {
        // Adds product to products list
        _products.Add(new Product(name, id, price, quantity));
    }

    public void SetCustomer(string name)
    {
        // Creates customer object for order
        _customer = new Customer(name);
    }

    public void SetAddress (string street, string city, string stateProvince, string country)
    {
        // Calls AddAddress from _customer to add address to the Order>Customer objects.
        _customer.AddAddress(street, city, stateProvince, country);
    }
}