﻿namespace Masa.Blazor.Experimental.Components;

public class Action : ComponentBase, IDisposable
{
    [CascadingParameter] private Actions? Actions { get; set; }

    [Parameter] public bool DisableAutoLoading { get; set; }

    [Parameter] public string Color { get; set; } = "primary";

    [Parameter] public string Icon { get; set; }

    [Parameter] public string Label { get; set; }

    [Parameter] public EventCallback OnClick { get; set; }

    [Parameter] public int Sort { get; set; }

    [Parameter] public bool Visible { get; set; } = true;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; } = new();

    public Action()
    {
    }

    public Action(string label, string icon, EventCallback onClick)
    {
        Label = label;
        Icon = icon;
        OnClick = onClick;
    }

    public Action(string label, string icon, string color, EventCallback onClick)
    {
        Label = label;
        Icon = icon;
        Color = color;
        OnClick = onClick;
    }

    private bool _prevVisible;
    private bool _shouldRender;

    public bool Loading { get; set; }

    public bool ShowTooltip => !string.IsNullOrWhiteSpace(Icon) && !string.IsNullOrWhiteSpace(Label);

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Actions?.AddButton(this);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _shouldRender = _prevVisible != Visible;

        _prevVisible = Visible;
    }

    protected override bool ShouldRender()
    {
        if (!_shouldRender) return false;

        Actions?.InvokeStateHasChanged();

        return true;
    }

    public void Dispose()
    {
        Actions?.RemoveButton(this);
    }
}