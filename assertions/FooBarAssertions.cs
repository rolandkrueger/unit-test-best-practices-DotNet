using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using TestDemo.dto;

namespace TestDemo.assertions;

public class FooBarAssertions(FooBar subject, AssertionChain chain)
    : ReferenceTypeAssertions<FooBar, FooBarAssertions>(subject, chain)
{
    protected override string Identifier => "foobar";
    private readonly AssertionChain _chain = chain;

    [CustomAssertion]
    public AndConstraint<FooBarAssertions> BeAProperFooBar(string because = "", params object[] becauseArgs)
    {
        _chain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject is not null && Subject.IsFoo && Subject.IsBar)
            .FailWith("{context:foobar} is not a proper FooBar (was: {0})", Subject);

        return new AndConstraint<FooBarAssertions>(this);
    }
}