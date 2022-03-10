namespace Masa.Blazor.Experimental.Components;

public class BlockTagProps
{
    public string Text { get; set; }

    public string Color { get; set; }
    
    public string Class { get; set; }

    public BlockTagProps()
    {
    }

    public BlockTagProps(string text, string color)
    {
        Text = text;
        Color = color;
    }
    
    public BlockTagProps(string text, string color, string @class)
    {
        Text = text;
        Color = color;
        Class = @class;
    }
}