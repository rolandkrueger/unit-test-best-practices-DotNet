using TestDemo.dto;

namespace TestDemo.builder;

public class AddressBuilder
{
    private string _street = "Musterstraße 1";
    private string _zipCode = "12345";
    private string _city = "Musterstadt";

    public Address Build()
    {
        return new Address(_street, _zipCode, _city);
    }

    public AddressBuilder WithStreet(string street)
    {
        _street = street;
        return this;
    }

    public AddressBuilder WithZipCode(string zipCode)
    {
        _zipCode = zipCode;
        return this;
    }

    public AddressBuilder WithCity(string city)
    {
        _city = city;
        return this;
    }
}