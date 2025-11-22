class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsUSA()
    {
        // If country is USA, return true. Else, return false
        if (_country == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetDisplayText()
    {
        // Display string for Address.
        return $"Address: {_street}\n{_city}, {_stateProvince}, {_country}";
    }
}