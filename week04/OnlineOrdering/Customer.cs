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
        // Adds address to customer object
        address = new Address(street, city, stateProvince, country);
    }

    public bool IsUSA()
    {
        // Passes IsUSA from address object.
        return address.IsUSA();
    }

    public string GetDisplayText()
    {
        // Displays Address information.
        return $"\nName: {_name}\n{address.GetDisplayText()}";
    }
}