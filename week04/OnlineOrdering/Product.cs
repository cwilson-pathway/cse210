using System.Data.Common;

class Product
{
    private string _name;
    private int _id;
    private float _price;
    private int _quantity;

    public Product(string name, int id, float price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public float SubtotalOfQuantity()
    {
        // Calculates subtotal from quantity
        return _price * _quantity;
    }

    public string GetPackingInfo()
    {
        // Gets packing info line.
        return $"\n{_name}, {_id}";
    }
}