using Microsoft.JSInterop;

namespace Masa.Blazor.Experimental.Components;

public partial class EllipsisText
{
    [Inject] private IJSRuntime Js { get; set; } = null!;

    [Parameter] public bool Bottom { get; set; }

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public bool Left { get; set; }

    [Parameter] public StringNumber? NudgeBottom { get; set; }
    
    [Parameter] public StringNumber? NudgeLeft { get; set; }
    
    [Parameter] public StringNumber? NudgeRight { get; set; }
    
    [Parameter] public StringNumber? NudgeTop { get; set; }

    [Parameter] public bool Right { get; set; }

    [Parameter] public string? Tooltip { get; set; }

    [Parameter] public string? TooltipClass { get; set; }

    [Parameter] public string? TooltipColor { get; set; }

    [Parameter] public bool Top { get; set; }

    protected override void OnParametersSet()
    {
        if (!(Left || Right || Bottom))
        {
            Top = true;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        IsDisabled = !(await IsEllipsis());
        if (_prevIsDisabled != IsDisabled)
        {
            StateHasChanged();
            _prevIsDisabled = IsDisabled;
        }
    }

    private bool _prevIsDisabled;

    private bool IsDisabled { get; set; }

    private ElementReference Ref { get; set; }

    private async Task<bool> IsEllipsis()
    {
        return await Js.InvokeAsync<bool>("MasaBlazorExperimental.isEllipsis", Ref);
    }
}