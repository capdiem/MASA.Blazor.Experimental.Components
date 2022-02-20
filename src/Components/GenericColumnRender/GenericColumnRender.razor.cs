namespace MASA.Blazor.Experimental.Components;

public partial class GenericColumnRender
{
    [Parameter] public Func<bool, string>? BoolRender { get; set; }

    [Parameter] public bool ChippedEnum { get; set; }

    [Parameter] public string? DateFormat { get; set; }

    [Parameter] public Func<DateTime, bool>? DefaultDateTimeChecker { get; set; }

    [Parameter] public bool IgnoreTime { get; set; }

    [Parameter] public bool SmallChip { get; set; }

    [Parameter] public string? TimeFormat { get; set; }

    [Parameter] [EditorRequired] public object Value { get; set; }

    protected object InternalValue { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        BoolRender ??= b => b ? "是" : "否";
        DefaultDateTimeChecker ??= dateTime => dateTime == default;

        InternalValue = Value;
    }
}