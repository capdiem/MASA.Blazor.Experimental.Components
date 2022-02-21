namespace MASA.Blazor.Experimental.Components;

public interface IPopupService
{
    Task<bool> ConfirmAsync(string title, string content, Func<PopupOkEventArgs<bool>, Task>? onOk = null);

    Task<object> OpenAsync(Type componentType, Dictionary<string, object> parameters);

    Task<string> PromptAsync(string title, string content, Func<PopupOkEventArgs<string>, Task>? onOk = null);

    Task<string> PromptAsync(string title, string content, Action<PromptParameters>? parameters = null);

    Task MessageAsync(string message, AlertTypes type = AlertTypes.None);

    Task MessageAsync(Exception ex);
}