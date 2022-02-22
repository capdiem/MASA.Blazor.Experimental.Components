namespace MASA.Blazor.Experimental.Components;

public class PopupService : IPopupService
{
    private readonly IPopupProvider _popupProvider;

    public PopupService(IPopupProvider popupProvider)
    {
        _popupProvider = popupProvider;
    }

    public Task<object> OpenAsync(Type componentType, Dictionary<string, object> parameters)
    {
        var item = _popupProvider.Add(componentType, parameters, this, nameof(PopupService));
        return item.TaskCompletionSource.Task;
    }

    public async Task<bool> ConfirmAsync(string title, string content)
    {
        ConfirmParameters param = new();

        var res = await OpenAsync(typeof(Confirm), param.ToDictionary(title, content));

        if (res is bool v)
        {
            return v;
        }

        return false;
    }

    public async Task<bool> ConfirmAsync(string title, string content, Func<PopupOkEventArgs, Task> onOk)
    {
        ConfirmParameters param = new()
        {
            OnOk = onOk
        };

        var res = await OpenAsync(typeof(Confirm), param.ToDictionary(title, content));

        if (res is bool v)
        {
            return v;
        }

        return false;
    }

    public async Task<string> PromptAsync(string title, string content,
        Func<PopupOkEventArgs<string>, Task>? onOk = null)
    {
        PromptParameters param = new()
        {
            OnOk = onOk
        };

        var res = await OpenAsync(typeof(Prompt), param.ToDictionary(title, content));

        return (string)res;
    }

    public async Task<string> PromptAsync(string title, string content, Action<PromptParameters>? parameters = null)
    {
        PromptParameters param = new();

        parameters?.Invoke(param);

        var res = await OpenAsync(typeof(Prompt), param.ToDictionary(title, content));

        return (string)res;
    }

    /// <inheritdoc />
    public Task MessageAsync(string message, AlertTypes type = AlertTypes.None)
    {
        _ = OpenAsync(typeof(Message), new Dictionary<string, object>()
        {
            { nameof(Message.Content), message },
            { nameof(Message.Type), type }
        });

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task MessageAsync(Exception ex)
    {
        _ = OpenAsync(typeof(Message), new Dictionary<string, object>()
        {
            { nameof(Message.Content), ex.Message },
            { nameof(Message.Type), AlertTypes.Error }
        });

        return Task.CompletedTask;
    }
}