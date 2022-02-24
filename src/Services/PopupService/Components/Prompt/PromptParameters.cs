namespace Masa.Blazor.Experimental.Components;

public class PromptParameters
{
    public Dictionary<string, object> Attributes { get; set; }

    public string? Placeholder { get; set; }

    public Func<PopupOkEventArgs<string>, Task>? OnOk { get; set; }

    public string Value { get; set; }

    public Dictionary<string, object> ToDictionary(string? title, string? content)
    {
        return new Dictionary<string, object>()
        {
            { "Title", title },
            { "Content", content },
            { nameof(Attributes), Attributes },
            { nameof(Placeholder), Placeholder },
            { nameof(OnOk), OnOk },
            { nameof(Value), Value },
        };
    }
}