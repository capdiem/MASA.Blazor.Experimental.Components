namespace Masa.Blazor.Experimental.Components;

public interface IPopupService
{
    Task<bool> ConfirmAsync(string title, string content);

    Task<bool> ConfirmAsync(string title, string content, Func<PopupOkEventArgs, Task> onOk);

    Task<object> OpenAsync(Type componentType, Dictionary<string, object> parameters);

    Task<string> PromptAsync(string title, string content);

    Task<string> PromptAsync(string title, string content, Action<PromptParameters> parameters);

    Task<string> PromptAsync(string title, string content, Func<PopupOkEventArgs<string>, Task> onOk);

    Task MessageAsync(string message, AlertTypes type = AlertTypes.None);

    Task MessageAsync(Exception ex);
}