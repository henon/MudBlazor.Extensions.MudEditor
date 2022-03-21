using System.Collections.ObjectModel;
using MudBlazor.Extensions.CustomIcons;
using MudBlazor.Extensions.Enums;
using static MudBlazor.Extensions.Enums.MudEditorEvent;
using static MudBlazor.Extensions.Enums.MudEditorValueType;


namespace MudBlazor.Extensions.Settings;

public record MudEditorEventSettings
{
    public MudEditorEventSettings(MudEditorEvent eventType, MudEditorValueType type, string? label = null,
        string icon = null!,
        MudEditorEvent[]? events = null)
    {
        EventType = eventType;
        Type = type;
        Icon = icon;
        Label = label;
        if (events != null) Events = new(events.Select(e => e.Settings()).ToList());
    }

    public MudEditorEvent EventType { get; }
    public MudEditorValueType Type { get; }
    public string? Label { get; }
    public string? Icon { get; }


    public ReadOnlyCollection<MudEditorEventSettings>? Events { get; init; }
}

internal static class MudEditorEventHelper
{
    public static MudEditorEventSettings Settings(this MudEditorEvent editorEvent)
    {
        switch (editorEvent)
        {
            case FontList:
                return new(FontList, List, "Font");
            case SizeList:
                return new(SizeList, List, "Size");
            case StyleGroup:
                return new(StyleGroup, Group,
                    events: new[] {BoldStyle, ItalicStyle, UnderlineStyle, StrikethroughStyle});
            case BoldStyle:
                return new(BoldStyle, Value, "Bold", Icons.Filled.FormatBold);
            case ItalicStyle:
                return new(ItalicStyle, Value, "Italic", Icons.Filled.FormatItalic);
            case UnderlineStyle:
                return new(UnderlineStyle, Value, "Underline", Icons.Filled.FormatUnderlined);
            case StrikethroughStyle:
                return new(StrikethroughStyle, Value, "Strikethrough", Icons.Filled.FormatStrikethrough);
            case ColorGroup:
                return new(ColorGroup, Group, events: new[] {FontColor, BackgroundColor});
            case FontColor:
                return new(FontColor, ColorPicker, "Font Color", Icons.Filled.FontDownload);
            case BackgroundColor:
                return new(BackgroundColor, ColorPicker, "Font Color", Icons.Filled.FormatColorText);
            case HeadingExpanded:
            case HeadingMenu:
                return new(editorEvent, editorEvent == HeadingExpanded ? Expanded : Menu,
                    events: new[] {Heading1, Heading2, Heading3, Heading4, Heading5, Heading6});
            case Heading1:
                return new(Heading1, Value, "H1", MudEditorIcons.Icons.H1);
            case Heading2:
                return new(Heading2, Value, "H2", MudEditorIcons.Icons.H2);
            case Heading3:
                return new(Heading3, Value, "H3", MudEditorIcons.Icons.H3);
            case Heading4:
                return new(Heading4, Value, "H4", MudEditorIcons.Icons.H4);
            case Heading5:
                return new(Heading5, Value, "H5", MudEditorIcons.Icons.H5);
            case Heading6:
                return new(Heading6, Value, "H6", MudEditorIcons.Icons.H6);
            case Quote:
                return new(Quote, Value, "Quote", Icons.Filled.FormatQuote);
            case Code:
                return new(Code, Value, "Code", Icons.Filled.Code);
            case ListGroup:
                return new(ListGroup, Group, events: new[] {ListNumbered, ListBulleted});
            case ListNumbered:
                return new(ListNumbered, Value, "Numbered List", Icons.Filled.FormatListNumbered);
            case ListBulleted:
                return new(ListBulleted, Value, "Bulleted List", Icons.Filled.FormatListBulleted);
            case IndentGroup:
                return new(IndentGroup, Group, events: new[] {IndentIncrease, IndentDecrease});
            case IndentIncrease:
                return new(IndentIncrease, Value, "Increase Indent", Icons.Filled.FormatIndentIncrease);
            case IndentDecrease:
                return new(IndentDecrease, Value, "Decrease Indent", Icons.Filled.FormatIndentDecrease);
            case AlignmentExpanded:
            case AlignmentMenu:
                return new(editorEvent, editorEvent == AlignmentExpanded ? Expanded : Menu,
                    events: new[] {AlignLeft, AlignCenter, AlignRight, AlignJustify});
            case AlignLeft:
                return new(AlignLeft, Value, "Align Left", Icons.Filled.FormatAlignLeft);
            case AlignCenter:
                return new(AlignCenter, Value, "Align Center", Icons.Filled.FormatAlignCenter);
            case AlignRight:
                return new(AlignRight, Value, "Align Right", Icons.Filled.FormatAlignRight);
            case AlignJustify:
                return new(AlignJustify, Value, "Justify", Icons.Filled.FormatAlignJustify);
            case DirectionExpanded:
            case DirectionToggle:
                return new(editorEvent, editorEvent == DirectionExpanded ? Expanded : Toggle,
                    events: new[] {DirectionLTR, DirectionRTL});
            case DirectionLTR:
                return new(DirectionLTR, Value, "Left to Right", Icons.Filled.FormatTextdirectionLToR);
            case DirectionRTL:
                return new(DirectionRTL, Value, "Right to Left", Icons.Filled.FormatTextdirectionRToL);
            case MediaGroup:
                return new(MediaGroup, Group, events: new[] {Link, Image, Video});
            case Link:
                return new(Link, Value, "Embed Link", Icons.Filled.InsertLink);
            case Image:
                return new(Image, Value, "Embed Image", Icons.Filled.Image);
            case Video:
                return new(Video, Value, "Embed Video", Icons.Filled.OndemandVideo);
            case MathGroup:
                return new(MathGroup, Group, events: new[] {Formula, Subscript, Superscript});
            case Formula:
                return new(Formula, Value, "Formula", MudEditorIcons.Icons.Fx);
            case Subscript:
                return new(Subscript, Value, "Subscript", Icons.Filled.Subscript);
            case Superscript:
                return new(Superscript, Value, "Superscript", Icons.Filled.Superscript);
            case FormatClear:
                return new(FormatClear, Value, "Clear Format", Icons.Filled.FormatClear);
            case Full:
                return new(Full, Group,
                    events: new[]
                    {
                        FontList, SizeList, StyleGroup, ColorGroup, HeadingMenu, Quote, Code, ListGroup, IndentGroup,
                        AlignmentMenu, DirectionToggle, MediaGroup, MathGroup, FormatClear
                    });
            default:
                throw new ArgumentOutOfRangeException(nameof(editorEvent), editorEvent, null);
        }
    }
}