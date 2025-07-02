using FluentAssertions;
using TestDemo.dependencyInversion;
using TestDemo.testobjects;

namespace TestDemo;

public class TestObjectsTest
{
    [Fact]
    public void TestStuffWithTestObjectsFactory()
    {
        var admin = TestObjects.Users().AdministratorUser();
        var item = TestObjects.ProductData().Items().StandardItem();
        var customer = TestObjects.CustomerDetails().PremiumCustomer();

        // use these test objects for the remainder of the test
    }
    
    [Theory]
    [TestUsers]
    public void TestStuffWithInjectionAndDefaultTestObject(User anon)
    {
        anon.Role.Should().Be("anonymous");
    }
    
    [Theory]
    [TestUsers(TestUserType.Administrator)]
    public void TestStuffWithInjection(User admin)
    {
        admin.Role.Should().Be("admin");
    }
    
    [Theory]
    [TestData]
    public void SomeTest(
        [TestUser(TestUserType.Administrator)] User admin,
        [TestUser(TestUserType.Customer)] User customer,
        ItemDto defaultItem,
        [TestItem(TestItemType.FullyConfigured)] ItemDto fullyConfiguredItem,
        string? unsupportedParameterType)
    {
        admin.Role.Should().Be("admin");
        customer.Role.Should().Be("customer");
        defaultItem.Name.Should().Be("Standard Item");
        fullyConfiguredItem.Name.Should().Be("Fully Configured Item");
        
        unsupportedParameterType.Should().BeNull();
    }
}