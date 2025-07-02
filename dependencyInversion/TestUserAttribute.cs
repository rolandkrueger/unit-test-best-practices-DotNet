namespace TestDemo.dependencyInversion;

[AttributeUsage(AttributeTargets.Parameter)]
public class TestUserAttribute(TestUserType kind) : Attribute
{
    public TestUserType Kind { get; } = kind;
}