namespace MudBlazor.Extensions;

public record MudEditorToolbarOptions
{
    public MudEditorToolbarOption A = new("test", "test");

    public MudEditorToolbarOptions(string[] options) { }
}

public struct MudEditorToolbarOption
{
    public MudEditorToolbarOption(string type, int value) : this(type, null, value) { }

    public MudEditorToolbarOption(string type, string value) : this(type, value, null) { }

    public MudEditorToolbarOption(string type, string? value = null, int? intValue = null)
    {
        Type = type;
        Value = value;
        IntValue = intValue;
    }

    public string Type { get; init; }
    public string? Value { get; init; }
    public int? IntValue { get; init; }
}