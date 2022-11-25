namespace Masa.Blazor.Experimental.Components;

public partial class Dropdown<TItem>
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public RenderFragment<ActivatorProps>? ActivatorContent { get; set; }

    [Parameter]
    public IEnumerable<TItem> Items { get; set; }

    [Parameter, EditorRequired]
    public Func<TItem, string> ItemKey { get; set; }

    [Parameter, EditorRequired]
    public Func<TItem, string> ItemText { get; set; }

    [Parameter]
    public Func<TItem, string> ItemIcon { get; set; }

    [Parameter]
    public RenderFragment<TItem> ItemContent { get; set; }

    [Parameter]
    public RenderFragment PrependContent { get; set; }

    [Parameter]
    public EventCallback<TItem> OnItemClick { get; set; }

    [Parameter]
    public string Value { get; set; }

    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }

    private void ItemValueChanged(StringNumber val)
    {
        if (ValueChanged.HasDelegate)
        {
            _ = ValueChanged.InvokeAsync(val?.ToString());
        }
        else
        {
            Value = val?.ToString();
        }
    }
}
