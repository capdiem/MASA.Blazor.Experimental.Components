namespace MASA.Blazor.Experimental.Components;

public class PopupOkEventArgs<T>
{
    public PopupOkEventArgs(T value)
    {
        Value = value;
    }
    
    public bool? Cancel { get; set; }
    
    public T Value { get; set; }
}