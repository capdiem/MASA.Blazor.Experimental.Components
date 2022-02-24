using Microsoft.JSInterop;

namespace Masa.Blazor.Experimental.Components;

public partial class CopyableText
{
    [Inject] public IJSRuntime Js { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public string Class { get; set; }

    [Parameter] public string ContentClass { get; set; }

    [Parameter] public string ContentStyle { get; set; }

    [Parameter] public string CopiedIcon { get; set; }

    [Parameter] public string CopyIcon { get; set; }

    [Parameter] public bool DisableTooltip { get; set; }

    [Parameter] public EventCallback OnCopy { get; set; }

    [Parameter] public string Style { get; set; }

    [Parameter] public string Text { get; set; }

    [Parameter] public string Tooltip { get; set; }
    
    private bool _copying;

    protected ElementReference Ref { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        CopiedIcon ??= "mdi-check";
        CopyIcon ??= "mdi-content-copy";
        Tooltip ??= "复制";
    }

    private string Icon => !_copying ? CopyIcon : CopiedIcon;

    private async Task HandleOnCopy()
    {
        if (_copying) return;

        _copying = true;

        await InvokeJsCopy();

        if (OnCopy.HasDelegate)
        {
            await OnCopy.InvokeAsync();
        }

        await Task.Delay(1000);

        _copying = false;
    }

    private async Task InvokeJsCopy()
    {
        if (string.IsNullOrEmpty(Text))
        {
            await Js.InvokeVoidAsync("MasaBlazorExperimental.copyChild", Ref);
        }
        else
        {
            await Js.InvokeVoidAsync("MasaBlazorExperimental.copyText", Text);
        }
    }
}