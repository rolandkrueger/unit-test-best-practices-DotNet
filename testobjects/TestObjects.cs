namespace TestDemo.testobjects;

public static class TestObjects
{
    public static UserProvider Users() => new UserProvider();
    public static CustomerDetailsProvider CustomerDetails() => new CustomerDetailsProvider();
    public static ProductDataProvider ProductData() => new ProductDataProvider();
}

public class UserProvider
{
    public User AdministratorUser() => new User("admin");
    public User AnonymousUser() => new User("anonymous");
    public User LimitedUser() => new User("limited");
    public User LockedUser() => new User("locked");
    public User CustomerUser() => new User("customer");
}

public class CustomerDetailsProvider
{
    public CustomerDetailsDto StandardCustomer() => new CustomerDetailsDto("standard");
    public CustomerDetailsDto ForeignCustomer() => new CustomerDetailsDto("foreign");
    public CustomerDetailsDto BlockedCustomer() => new CustomerDetailsDto("blocked");
    public CustomerDetailsDto PremiumCustomer() => new CustomerDetailsDto("premium");
}

public class ProductDataProvider
{
    public ItemProvider Items() => new ItemProvider();
}

public class ItemProvider
{
    public ItemDto StandardItem() => new ItemDto("Standard Item");
    public ItemDto UnconfiguredItem() => new ItemDto("Unconfigured Item");
    public ItemDto FullyConfiguredItem() => new ItemDto("Fully Configured Item");
}

// Dummy-Datentypen
public record User(string Role);
public record CustomerDetailsDto(string Type);
public record ItemDto(string Name);