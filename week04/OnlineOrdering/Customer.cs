class Customer
{
    private string _name;
    private Address address;

    public Customer(string name)
    {
        _name = name;
    }

    public void AddAddress(string street, string city, string stateProvince, string country)
    {
        address = new Address(street, city, stateProvince, country);
    }

    public bool IsUSA()
    {
        return address.IsUSA();
    }

    public string GetDisplayText()
    {
        return $"\nName: {_name}\n{address.GetDisplayText()}";
    }
}