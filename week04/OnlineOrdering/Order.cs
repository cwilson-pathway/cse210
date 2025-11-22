using System.Data.SqlTypes;

class Order 
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public float OrderTotal()
    {
        float subTotal = 0;
        foreach (Product product in _products)
        {
            subTotal += product.SubtotalOfQuantity();
        }
        
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
        string packingString = "";
        foreach (Product product in _products)
        {
            packingString += product.GetPackingInfo();
        }

        return packingString;
    }

    public string GetShippingLabel()
    {
        return _customer.GetDisplayText();
    }

    public void AddProduct(string name, int id, float price, int quantity)
    {
        _products.Add(new Product(name, id, price, quantity));
    }

    public void SetCustomer(string name)
    {
        _customer = new Customer(name);
    }

    public void SetAddress (string street, string city, string stateProvince, string country)
    {
        _customer.AddAddress(street, city, stateProvince, country);
    }
}