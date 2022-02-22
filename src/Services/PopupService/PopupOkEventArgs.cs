namespace MASA.Blazor.Experimental.Components;

public class PopupOkEventArgs
{
    public bool? Cancel { get; set; }
}

public class PopupOkEventArgs<T> : PopupOkEventArgs
{
    public PopupOkEventArgs(T value)
    {
        Value = value;
    }

    public T Value { get; }
}