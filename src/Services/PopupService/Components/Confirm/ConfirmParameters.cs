namespace MASA.Blazor.Experimental.Components;

public class ConfirmParameters
{
    public Dictionary<string, object> Attributes { get; set; }

    public Func<PopupOkEventArgs<bool>, Task>? OnOk { get; set; }

    public Dictionary<string, object> ToDictionary(string? title, string? content)
    {
        return new Dictionary<string, object>()
        {
            { "Title", title },
            { "Content", content },
            { nameof(Attributes), Attributes },
            { nameof(OnOk), OnOk }
        };
    }
}