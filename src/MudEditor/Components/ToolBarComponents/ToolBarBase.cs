using Microsoft.AspNetCore.Components;

namespace MudBlazor.Extensions.ToolBarComponents;

public class ToolBarBase<T> : ComponentBase
{
    [Parameter]
    public ToolBarOption Options { get; set; } = null!;

    [Parameter]
    public Color ActiveColor { get; set; } = Color.Primary;

    [Parameter]
    public Color DefaultColor { get; set; } = Color.Default;

    [Parameter]
    public bool Active { get; set; }

    [Parameter]
    public virtual T? Value { get; set; }
}