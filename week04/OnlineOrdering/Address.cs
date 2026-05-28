class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public string Street => _street;
    public string City => _city;
    public string StateOrProvince => _stateOrProvince;
    public string Country => _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return string.Equals(_country?.Trim(), "USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFormattedAddress()
    {
        return $"{Street}\n{City}, {StateOrProvince}\n{Country}";
    }
}
