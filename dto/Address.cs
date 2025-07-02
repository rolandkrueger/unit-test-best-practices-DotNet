namespace TestDemo.dto;

public class Address
{
    public string Street { get; }
    public string ZipCode { get; }
    public string City { get; }

    public Address(string street, string zipCode, string city)
    {
        Street = street;
        ZipCode = zipCode;
        City = city;
    }

    public override string ToString() => $"{Street}, {ZipCode} {City}";
}