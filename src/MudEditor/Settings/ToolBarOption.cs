using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using MudBlazor.Extensions.CustomIcons;
using MudBlazor.Extensions.Settings;
using static MudBlazor.Extensions.Settings.ToolBarGroupType;

namespace MudBlazor.Extensions;

public class ToolBarOption : Enumeration
{
    public static readonly ToolBarOption FontList = new(1, List);

    public static readonly ToolBarOption SizeList = new(2, List);

    public static readonly ToolBarOption BoldStyle = new(3, Btn, "Bold", Icons.Filled.FormatBold);
    public static readonly ToolBarOption ItalicStyle = new(4, Btn, "Italic", Icons.Filled.FormatItalic);
    public static readonly ToolBarOption UnderlineStyle = new(5, Btn, "Underline", Icons.Filled.FormatUnderlined);

    public static readonly ToolBarOption StrikethroughStyle =
        new(6, Btn, "Strikethrough", Icons.Filled.FormatStrikethrough);

    public static readonly ToolBarOption StyleGroup = new(7, Group,
        options: new[] {BoldStyle, ItalicStyle, UnderlineStyle, StrikethroughStyle});

    public static readonly ToolBarOption FontColor = new(8, ColorPicker, "Font Color", Icons.Filled.FormatColorText);

    public static readonly ToolBarOption BackgroundColor =
        new(9, ColorPicker, "Background Color", Icons.Filled.FontDownload);

    public static readonly ToolBarOption ColorGroup = new(10, Group, options: new[] {FontColor, BackgroundColor});

    public static readonly ToolBarOption Heading1 = new(11, Btn, "H1", MudEditorIcons.Icons.H1);
    public static readonly ToolBarOption Heading2 = new(12, Btn, "H2", MudEditorIcons.Icons.H2);
    public static readonly ToolBarOption Heading3 = new(13, Btn, "H3", MudEditorIcons.Icons.H3);
    public static readonly ToolBarOption Heading4 = new(14, Btn, "H4", MudEditorIcons.Icons.H4);
    public static readonly ToolBarOption Heading5 = new(15, Btn, "H5", MudEditorIcons.Icons.H5);
    public static readonly ToolBarOption Heading6 = new(16, Btn, "H6", MudEditorIcons.Icons.H6);

    public static readonly ToolBarOption HeadingMenu =
        new(17, Menu, options: new[] {Heading1, Heading2, Heading3, Heading4, Heading5, Heading6});

    public static readonly ToolBarOption HeadingExpanded = new(18, Expanded,
        options: new[] {Heading1, Heading2, Heading3, Heading4, Heading5, Heading6});

    public static readonly ToolBarOption Quote = new(19, Btn, "Quote", Icons.Filled.FormatQuote);

    public static readonly ToolBarOption Code = new(20, Btn, "Code", Icons.Filled.Code);

    public static readonly ToolBarOption ListNumbered = new(21, Btn, "Numbered List", Icons.Filled.FormatListNumbered);
    public static readonly ToolBarOption ListBulleted = new(22, Btn, "Bulleted List", Icons.Filled.FormatListBulleted);

    public static readonly ToolBarOption ListGroup = new(21, Group, options: new[]
        {ListNumbered, ListBulleted});

    public static readonly ToolBarOption IndentIncrease =
        new(25, Btn, "Increase Indent", Icons.Filled.FormatIndentIncrease);

    public static readonly ToolBarOption IndentDecrease =
        new(26, Btn, "Decrease Indent", Icons.Filled.FormatIndentDecrease);


    public static readonly ToolBarOption IndentGroup = new(24, Group, options: new[] {IndentIncrease, IndentDecrease});

    public static readonly ToolBarOption AlignLeft = new(29, Btn, "Align Left", Icons.Filled.FormatAlignLeft);
    public static readonly ToolBarOption AlignCenter = new(30, Btn, "Align Center", Icons.Filled.FormatAlignCenter);
    public static readonly ToolBarOption AlignRight = new(31, Btn, "Align Right", Icons.Filled.FormatAlignRight);
    public static readonly ToolBarOption AlignJustify = new(32, Btn, "Justify", Icons.Filled.FormatAlignJustify);

    public static readonly ToolBarOption AlignmentMenu =
        new(27, Menu, options: new[] {AlignLeft, AlignCenter, AlignRight, AlignJustify});

    public static readonly ToolBarOption AlignmentExpanded =
        new(28, Expanded, options: new[] {AlignLeft, AlignCenter, AlignRight, AlignJustify});

    internal static readonly ToolBarOption LTR = new(35, Btn, "Left to Right", Icons.Filled.FormatTextdirectionLToR);
    internal static readonly ToolBarOption RTL = new(36, Btn, "Right to Left", Icons.Filled.FormatTextdirectionRToL);

    public static readonly ToolBarOption LTRToggle = new(33, Toggle, options: new[] {LTR, RTL});

    public static readonly ToolBarOption LRTExpanded = new(34, Expanded, options: new[] {LTR, RTL});

    public static readonly ToolBarOption Link = new(38, Btn, "Embed Link", Icons.Filled.InsertLink);
    public static readonly ToolBarOption Image = new(39, Btn, "Embed Image", Icons.Filled.Image);
    public static readonly ToolBarOption Video = new(40, Btn, "Embed Video", Icons.Filled.OndemandVideo);

    public static readonly ToolBarOption MediaGroup = new(37, Group, options: new[] {Link, Image, Video});

    public static readonly ToolBarOption Formula = new(42, Btn, "Formula", MudEditorIcons.Icons.Fx);
    public static readonly ToolBarOption Subscript = new(43, Btn, "Subscript", Icons.Filled.Subscript);
    public static readonly ToolBarOption Superscript = new(44, Btn, "Superscript", Icons.Filled.Superscript);

    public static readonly ToolBarOption MathGroup = new(41, Group, options: new[] {Formula, Subscript, Superscript});

    public static readonly ToolBarOption FormatClear = new(45, Btn, "Clear Format", Icons.Filled.FormatClear);

    internal static readonly ToolBarOption Full =
        new(0, ToolBarBase,
            options: new[]
            {
                FontList, SizeList, StyleGroup,
                ColorGroup, HeadingMenu, Quote,
                Code, ListGroup, IndentGroup,
                AlignmentMenu, LTRToggle, MediaGroup,
                MathGroup, FormatClear
            });

    private ToolBarOption(int value, ToolBarGroupType type, string? label = null,
        string icon = null!, ToolBarOption[]? options = null, [CallerMemberName] string name = null!) : base(value,
        name)
    {
        Type = type;
        Icon = icon;
        Label = label;

        if (type.Equals(Btn)) options = new[] {this};

        if (options != null) Options = new(options);

        Parameters = new Dictionary<string, object> {{"Options", this}};
    }

    public ToolBarGroupType Type { get; }

    public string? Label { get; }

    public string? Icon { get; }

    public IDictionary<string, object> Parameters { get; }

    public ReadOnlyCollection<ToolBarOption>? Options { get; }

    public static ToolBarOption CustomToolBarOption(ToolBarGroup[] groups)
    {
        var index = GetAll<ToolBarOption>().Count();
        var events = groups.Select(g =>
                g.Events.Length == 1 && g.Events[0].Type.Equals(Group)
                    ? g.Events[0]
                    : new(index++, Group, options: g.Events))
            .ToList();

        return new(index++, ToolBarBase, options: events.ToArray());
    }

    public record ToolBarGroup(ToolBarOption[] Events);
}