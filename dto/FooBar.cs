namespace TestDemo.dto;

public class FooBar
{
    public bool IsFoo { get; }
    public bool IsBar { get; }

    public FooBar(bool isFoo, bool isBar)
    {
        IsFoo = isFoo;
        IsBar = isBar;
    }

    public override string ToString()
    {
        return $"FooBar{{IsFoo={IsFoo}, IsBar={IsBar}}}";
    }
}