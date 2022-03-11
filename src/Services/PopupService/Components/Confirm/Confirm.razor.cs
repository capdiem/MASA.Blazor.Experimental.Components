namespace Masa.Blazor.Experimental.Components;

public partial class Confirm : PopupComponentBase
{
    [Parameter] public string? ActionsClass { get; set; }

    [Parameter] public string? ActionsStyle { get; set; }

    [Parameter] public string? CancelText { get; set; }

    [Parameter] public Action<ModalButtonProps>? CancelProps { get; set; }

    [Parameter] public string? Content { get; set; }

    [Parameter] public string? ContentClass { get; set; }

    [Parameter] public string? ContentStyle { get; set; }

    [Parameter] public string? Icon { get; set; }

    [Parameter] public string? IconColor { get; set; }

    [Parameter] public Func<PopupOkEventArgs<bool>, Task>? OnOk { get; set; }

    [Parameter] public string? OkText { get; set; }

    [Parameter] public Action<ModalButtonProps>? OkProps { get; set; }

    [Parameter] public string? Title { get; set; }

    [Parameter] public string? TitleClass { get; set; }

    [Parameter] public string? TitleStyle { get; set; }

    [Parameter] public AlertTypes? Type { get; set; }

    private bool _okLoading;
    private ConfirmParameters? _defaultConfirmParameters;

    private ModalButtonProps? ComputedOkButtonProps { get; set; }

    private ModalButtonProps? ComputedCancelButtonProps { get; set; }

    private string? ComputedIcon
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(Icon))
            {
                return Icon;
            }

            return Type switch
            {
                AlertTypes.Success => "mdi-checkbox-marked-circle-outline",
                AlertTypes.Error => "mdi-alert-circle-outline",
                AlertTypes.Info => "mdi-information",
                AlertTypes.Warning => "mdi-alert-outline",
                _ => null
            };
        }
    }

    private string? ComputedIconColor
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(IconColor))
            {
                return IconColor;
            }

            return Type switch
            {
                AlertTypes.Success => "success",
                AlertTypes.Info => "info",
                AlertTypes.Warning => "warning",
                AlertTypes.Error => "error",
                _ => null
            };
        }
    }

    protected override void OnParametersSet()
    {
        if (!Visible)
        {
            base.OnParametersSet();
            return;
        }

        if (_defaultConfirmParameters is null && MasaPopupProvider?.ConfirmParameters is not null)
        {
            _defaultConfirmParameters = new ConfirmParameters();

            MasaPopupProvider.ConfirmParameters?.Invoke(_defaultConfirmParameters);
        }

        _defaultConfirmParameters?.MapTo(this);

        base.OnParametersSet();

        OkText ??= "Ok";
        CancelText ??= "Cancel";

        ComputedOkButtonProps = GetDefaultSaveButtonProps();
        ComputedCancelButtonProps = GetDefaultCancelButtonProps();

        if (!string.IsNullOrEmpty(ComputedIconColor))
        {
            ComputedOkButtonProps.Color = ComputedIconColor;
        }

        OkProps?.Invoke(ComputedOkButtonProps);
        CancelProps?.Invoke(ComputedCancelButtonProps);
    }

    private Task HandleOnCancel()
    {
        Visible = false;
        return SetResult(false);
    }

    private async Task HandleOnSave()
    {
        PopupOkEventArgs<bool> args = new(true);

        if (OnOk != null)
        {
            _okLoading = true;
            await OnOk.Invoke(args);
            _okLoading = false;
        }

        if (args.Cancel is null or false)
        {
            Visible = false;
            await SetResult(true);
        }
    }

    private async Task SetResult(bool value)
    {
        if (PopupItem is not null)
        {
            await Task.Delay(256);
            PopupItem.Discard(value);
        }
    }

    protected virtual ModalButtonProps GetDefaultSaveButtonProps() => new()
    {
        Color = "primary",
        Text = true,
    };

    protected virtual ModalButtonProps GetDefaultCancelButtonProps() => new()
    {
        Text = true
    };
}