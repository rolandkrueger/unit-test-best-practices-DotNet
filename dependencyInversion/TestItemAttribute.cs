namespace TestDemo.dependencyInversion;

[AttributeUsage(AttributeTargets.Parameter)]
public class TestItemAttribute(TestItemType kind) : Attribute
{
    public TestItemType Kind { get; } = kind;
}