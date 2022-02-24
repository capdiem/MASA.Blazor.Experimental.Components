namespace Masa.Blazor.Experimental.Components;

public class PopupComponentBase : ComponentBase
{
    [CascadingParameter]
    protected ProviderItem PopupItem { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }

    protected bool Visible { get; set; }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);

        Visible = true;
    }
}