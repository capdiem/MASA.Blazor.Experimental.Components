using System.Collections;

namespace Masa.Blazor.Experimental.Components;

public partial class PDatePicker<TValue>
{
    #region MTextField Parameters

    [Parameter] public bool Clearable { get; set; }
    [Parameter] public bool Dense { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public StringBoolean HideDetails { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public EventCallback<MouseEventArgs> OnClearClick { get; set; }
    [Parameter] public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }
    [Parameter] public bool Outlined { get; set; }
    [Parameter] public string PrependIcon { get; set; }
    [Parameter] public string PrependInnerIcon { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; } = new();

    #endregion

    #region MDatePicker Parameters

    [Parameter] public bool NoTitle { get; set; }
    [Parameter] public bool Range { get; set; }
    [Parameter] public bool Scrollable { get; set; }
    [Parameter] public TValue Value { get; set; }
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }

    #endregion

    [Parameter] public TValue? DefaultSelectedValue { get; set; }
    [Parameter] public string? Format { get; set; }
    [Parameter] public EventCallback OnOk { get; set; }

    private bool _menuValue;

    private TValue InternalValue { get; set; }

    private string TextFieldValue
    {
        get
        {
            return Value switch
            {
                DateOnly date when date != DateOnly.MinValue => date.ToString(Format),
                // TODO: DateOnly.MinValue in dates?
                IList<DateOnly> dates => string.Join(" ~ ", dates.Select(date => date.ToString(Format))),
                _ => string.Empty
            };
        }
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        PrependInnerIcon = "mdi-calendar";

        await base.SetParametersAsync(parameters);

        if (!Range && Value is DateOnly date)
        {
            if (date == default)
            {
                throw new ArgumentException($"{nameof(Value)} cannot be DateOnly.MinValue");
            }

            UpdateInternalValue((TValue)(object)date);
        }
    }

    private void HandleOnCancel()
    {
        _menuValue = false;
    }

    private async Task HandleOnClearClick()
    {
        await UpdateValue(default);

        if (OnClearClick.HasDelegate)
        {
            await OnClearClick.InvokeAsync();
        }
    }

    private async Task HandleOnOk()
    {
        await UpdateValue(InternalValue);

        _menuValue = false;

        if (OnOk.HasDelegate)
        {
            await OnOk.InvokeAsync();
        }
    }

    private void InternalValueChanged(TValue value)
    {
        InternalValue = value;
    }

    private void MenuValueChanged(bool value)
    {
        if (value)
        {
            InternalValue = Value;

            if (InternalValue == null || InternalValue.Equals(default))
            {
                UpdateInternalValue(DefaultSelectedValue);
            }
        }

        _menuValue = value;
    }

    private void OnNow()
    {
        object now;

        var todayDate = DateOnly.FromDateTime(DateTime.Now);

        if (Range)
        {
            now = new List<DateOnly>() { todayDate, todayDate };
        }
        else
        {
            now = todayDate;
        }

        UpdateInternalValue((TValue)now);
    }

    private void UpdateInternalValue(TValue? value)
    {
        InternalValue = value;
    }

    private async Task UpdateValue(TValue value)
    {
        if (ValueChanged.HasDelegate)
        {
            await ValueChanged.InvokeAsync(value);
        }
        else
        {
            Value = value;
        }
    }
}