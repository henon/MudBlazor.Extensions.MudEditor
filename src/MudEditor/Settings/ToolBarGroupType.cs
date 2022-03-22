using System.Runtime.CompilerServices;
using MudBlazor.Extensions.ToolBarComponents;

namespace MudBlazor.Extensions.Settings;

public class ToolBarGroupType : Enumeration
{
    internal static readonly ToolBarGroupType Expanded = new(0, typeof(ToolBarExpanded));
    internal static readonly ToolBarGroupType Menu = new(1, typeof(ToolBarMenu));
    internal static readonly ToolBarGroupType Toggle = new(2, typeof(ToolBarToggle));
    internal static readonly ToolBarGroupType List = new(3, typeof(ToolBarList));
    internal static readonly ToolBarGroupType Group = new(4, typeof(ToolBarGroup));
    internal static readonly ToolBarGroupType Btn = new(5, typeof(ToolBarGroup));
    internal static readonly ToolBarGroupType ColorPicker = new(6, typeof(ToolBarColorPicker));
    internal static readonly ToolBarGroupType ToolBarBase = new(7);

    private ToolBarGroupType(int value, Type componentType = null!, [CallerMemberName] string name = null!) :
        base(value, name)
    {
        ComponentType = componentType;
        //Parameters = new Dictionary<string, object> {{"Options", this}};
    }

    public Type ComponentType { get; }

    //public IDictionary<string, object> Parameters { get; }
}