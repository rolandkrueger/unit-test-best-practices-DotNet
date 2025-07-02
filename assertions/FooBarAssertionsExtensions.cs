using FluentAssertions.Execution;
using TestDemo.dto;

namespace TestDemo.assertions;

public static class FooBarAssertionsExtensions
{
    public static FooBarAssertions Should(this FooBar instance)
    {
        return new FooBarAssertions(instance, AssertionChain.GetOrCreate());
    }
}