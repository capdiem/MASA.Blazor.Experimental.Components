﻿namespace Masa.Blazor.Experimental.Components;

public partial class Actions
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public int DisplayCount { get; set; } = 2;

    [Parameter] public IEnumerable<Action>? Items { get; set; }

    private List<Action> ChildActions { get;  } = new();

    private IEnumerable<Action> VisibleItems => Items?.Where(item => item.Visible) ?? Enumerable.Empty<Action>();

    private IEnumerable<Action> DisplayItems =>
        Count >= DisplayCount ? VisibleItems.Take(DisplayCount) : VisibleItems;

    private IEnumerable<Action> MenuItems =>
        Count > DisplayCount ? VisibleItems.Skip(DisplayCount).Take(Count - DisplayCount) : Enumerable.Empty<Action>();

    private int Count => Items?.Count() ?? 0;

    private bool ShowMenu => MenuItems.Any();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        Items ??= Enumerable.Empty<Action>();
    }

    internal void InvokeStateHasChanged()
    {
        StateHasChanged();
    }

    internal void AddButton(Action action)
    {
        ChildActions.Add(action);

        Items = ChildActions.OrderBy(item => item.Sort);

        StateHasChanged();
    }

    internal void RemoveButton(Action action)
    {
        ChildActions.Remove(action);

        Items = ChildActions.OrderBy(item => item.Sort);

        StateHasChanged();
    }

    private async Task OnClickProxy(Action action)
    {
        if (action.DisableAutoLoading)
        {
            await action.OnClick.InvokeAsync();
        }
        else
        {
            action.Loading = true;

            await action.OnClick.InvokeAsync();

            action.Loading = false;
        }
    }
}