using TestDemo.testobjects;

namespace TestDemo.dependencyInversion;

using Xunit.Sdk;
using System.Reflection;

public class TestDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var parameters = testMethod.GetParameters();
        var args = parameters.Select(ResolveParameter).ToArray();
        yield return args!;
    }

    private object? ResolveParameter(ParameterInfo parameter)
    {
        if (parameter.ParameterType == typeof(User))
        {
            var defaultUser = TestObjects.Users().AnonymousUser();
            var attr = parameter.GetCustomAttribute<TestUserAttribute>();
            if (attr == null) return defaultUser;

            return attr.Kind switch
            {
                TestUserType.Administrator => TestObjects.Users().AdministratorUser(),
                TestUserType.Customer => TestObjects.Users().CustomerUser(),
                TestUserType.Anonymous => TestObjects.Users().AnonymousUser(),
                TestUserType.Limited => TestObjects.Users().LimitedUser(),
                TestUserType.Locked => TestObjects.Users().LockedUser(),
                _ => defaultUser
            };
        }

        if (parameter.ParameterType == typeof(ItemDto))
        {
            var defaultItem = TestObjects.ProductData().Items().StandardItem();
            var attr = parameter.GetCustomAttribute<TestItemAttribute>();
            if (attr == null) return defaultItem;
            
            return attr.Kind switch
            {
                TestItemType.FullyConfigured => TestObjects.ProductData().Items().FullyConfiguredItem(),
                TestItemType.Standard => TestObjects.ProductData().Items().StandardItem(),
                TestItemType.Unconfigured => TestObjects.ProductData().Items().UnconfiguredItem(),
                _ => defaultItem
            };
        }

        return null;
    }
}