using TestDemo.assertions;
using TestDemo.dto;

namespace TestDemo;

public class CustomAssertionTest
{
    [Fact(DisplayName = "FooBar Test")]
    public void TestFooBar()
    {
        var fooBar = new FooBar(isFoo: true, isBar: true);
        fooBar.Should().BeAProperFooBar().And.NotBeNull(); 

        var broken = new FooBar(isFoo: true, isBar: false);
        broken.Should().BeAProperFooBar(); 
    }
}