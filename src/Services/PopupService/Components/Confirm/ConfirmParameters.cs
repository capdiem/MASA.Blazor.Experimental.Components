﻿namespace Masa.Blazor.Experimental.Components;

public class ConfirmParameters : Confirm
{
    public ConfirmParameters()
    {
    }

    public ConfirmParameters(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>
        {
            [nameof(ActionsClass)] = ActionsClass,
            [nameof(ActionsStyle)] = ActionsStyle,
            [nameof(Attributes)] = Attributes,
            [nameof(CancelProps)] = CancelProps,
            [nameof(CancelText)] = CancelText,
            [nameof(Content)] = Content,
            [nameof(ContentClass)] = ContentClass,
            [nameof(ContentStyle)] = ContentStyle,
            [nameof(Icon)] = Icon,
            [nameof(IconColor)] = IconColor,
            [nameof(OnOk)] = OnOk,
            [nameof(OkProps)] = OkProps,
            [nameof(OkText)] = OkText,
            [nameof(Title)] = Title,
            [nameof(TitleClass)] = TitleClass,
            [nameof(TitleStyle)] = TitleStyle,
            [nameof(Type)] = Type,
        };
    }

    internal void MapTo(Confirm component)
    {
        component.ActionsClass ??= ActionsClass;
        component.ActionsStyle ??= ActionsStyle;
        component.CancelProps ??= CancelProps;
        component.CancelText ??= CancelText;
        component.Content ??= Content;
        component.ContentClass ??= ContentClass;
        component.ContentStyle ??= ContentStyle;
        component.Icon ??= Icon;
        component.IconColor ??= IconColor;
        component.OkProps ??= OkProps;
        component.OkText ??= OkText;
        component.OnOk ??= OnOk;
        component.Title ??= Title;
        component.TitleClass ??= TitleClass;
        component.TitleStyle ??= TitleStyle;
        component.Type ??= Type;
        component.Attributes ??= Attributes;
    }
}