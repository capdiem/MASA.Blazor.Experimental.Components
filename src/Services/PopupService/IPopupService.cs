namespace Masa.Blazor.Experimental.Components;

public interface IPopupService
{
    #region Confirm

    Task<bool> ConfirmAsync(string title, string content);

    Task<bool> ConfirmAsync(string title, string content, AlertTypes type);

    Task<bool> ConfirmAsync(string title, string content, AlertTypes type, Func<PopupOkEventArgs, Task> onOk);

    Task<bool> ConfirmAsync(string title, string content, Func<PopupOkEventArgs, Task> onOk);

    Task<bool> ConfirmAsync(Action<ConfirmParameters> parameters);

    #endregion

    Task<object> OpenAsync(Type componentType, Dictionary<string, object> parameters);

    #region Prompt

    Task<string> PromptAsync(string title, string content);

    Task<string> PromptAsync(string title, string content, Action<PromptParameters> parameters);

    Task<string> PromptAsync(string title, string content, Func<PopupOkEventArgs<string>, Task> onOk);

    #endregion

    #region Message

    Task MessageAsync(string message, AlertTypes type = AlertTypes.None);

    Task MessageAsync(Exception ex);

    #endregion
}