namespace Masa.Blazor.Experimental.Components;

public partial class PopupService : IPopupService
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

    public async Task<string> PromptAsync(string title, string content)
    {
        PromptParameters param = new();

        var res = await OpenAsync(typeof(Prompt), param.ToDictionary(title, content));

        return (string)res;
    }

    public async Task<string> PromptAsync(string title, string content, Func<PopupOkEventArgs<string>, Task> onOk)
    {
        PromptParameters param = new()
        {
            OnOk = onOk
        };

        var res = await OpenAsync(typeof(Prompt), param.ToDictionary(title, content));

        return (string)res;
    }

    public async Task<string> PromptAsync(string title, string content, Action<PromptParameters> parameters)
    {
        PromptParameters param = new();

        parameters.Invoke(param);

        var res = await OpenAsync(typeof(Prompt), param.ToDictionary(title, content));

        return (string)res;
    }
}