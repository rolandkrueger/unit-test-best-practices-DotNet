using System.Reflection;
using TestDemo.testobjects;
using Xunit.Sdk;

namespace TestDemo.dependencyInversion;

public class TestUsersForMethodAttribute(TestUserType userType = TestUserType.Anonymous) : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return [GetUser(userType)];
    }

    private User GetUser(TestUserType type) => type switch
    {
        TestUserType.Administrator => TestObjects.Users().AdministratorUser(),
        TestUserType.Limited => TestObjects.Users().LimitedUser(),
        TestUserType.Anonymous => TestObjects.Users().AnonymousUser(),
        TestUserType.Locked => TestObjects.Users().LockedUser(),
        TestUserType.Customer => TestObjects.Users().CustomerUser(),
        _ => TestObjects.Users().AnonymousUser()
    };
}

[AttributeUsage(AttributeTargets.Parameter)]
public class TestUserAttribute(TestUserType kind) : Attribute
{
    public TestUserType Kind { get; } = kind;
}

[AttributeUsage(AttributeTargets.Parameter)]
public class TestItemAttribute(TestItemType kind) : Attribute
{
    public TestItemType Kind { get; } = kind;
}