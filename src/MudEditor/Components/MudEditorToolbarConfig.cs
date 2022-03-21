namespace MudBlazor.Extensions;

public record MudEditorToolbarConfig
{
    private MudEditorToolbarConfig(bool showFontControls, bool showSizeControls, bool showStyleControls,
        bool showColorControls, bool showHeaderControls,
        bool showQuotationControls, bool showCodeBlockControls, bool showListControls, bool showIndentationControls,
        bool showAlignmentControls,
        bool showDirectionControls, bool showHypertextLinkControls, bool showInsertImageControls,
        bool showEmbedVideoControls, bool showMathControls,
        bool showCleanFormattingControls)
    {
        ShowFontControls = showFontControls;
        ShowSizeControls = showSizeControls;
        ShowStyleControls = showStyleControls;
        ShowColorControls = showColorControls;
        ShowHeaderControls = showHeaderControls;
        ShowQuotationControls = showQuotationControls;
        ShowCodeBlockControls = showCodeBlockControls;
        ShowListControls = showListControls;
        ShowIndentationControls = showIndentationControls;
        ShowAlignmentControls = showAlignmentControls;
        ShowDirectionControls = showDirectionControls;
        ShowHypertextLinkControls = showHypertextLinkControls;
        ShowInsertImageControls = showInsertImageControls;
        ShowEmbedVideoControls = showEmbedVideoControls;
        ShowMathControls = showMathControls;
        ShowCleanFormattingControls = showCleanFormattingControls;
    }


    public bool ShowFontControls { get; set; }
    public bool ShowSizeControls { get; set; }
    public bool ShowStyleControls { get; set; }
    public bool ShowColorControls { get; set; }
    public bool ShowHeaderControls { get; set; }
    public bool ShowQuotationControls { get; set; }
    public bool ShowCodeBlockControls { get; set; }
    public bool ShowListControls { get; set; }
    public bool ShowIndentationControls { get; set; }
    public bool ShowAlignmentControls { get; set; }
    public bool ShowDirectionControls { get; set; }
    public bool ShowHypertextLinkControls { get; set; }
    public bool ShowInsertImageControls { get; set; }
    public bool ShowEmbedVideoControls { get; set; }
    public bool ShowMathControls { get; set; }
    public bool ShowCleanFormattingControls { get; set; }

    public static MudEditorToolbarConfig CreateInstance(
        bool showFontControls = true,
        bool showSizeControls = false,
        bool showStyleControls = false,
        bool showColorControls = false,
        bool showHeaderControls = false,
        bool showQuotationControls = false,
        bool showCodeBlockControls = false,
        bool showListControls = false,
        bool showIndentationControls = false,
        bool showAlignmentControls = false,
        bool showDirectionControls = false,
        bool showHypertextLinkControls = false,
        bool showInsertImageControls = false,
        bool showEmbedVideoControls = false,
        bool showMathControls = false,
        bool showCleanFormattingControls = false)
    {
        return new MudEditorToolbarConfig(showFontControls,
            showSizeControls,
            showStyleControls,
            showColorControls,
            showHeaderControls,
            showQuotationControls,
            showCodeBlockControls,
            showListControls,
            showIndentationControls,
            showAlignmentControls,
            showDirectionControls,
            showHypertextLinkControls,
            showInsertImageControls,
            showEmbedVideoControls,
            showMathControls,
            showCleanFormattingControls);
    }

    public static MudEditorToolbarConfig FullToolBar()
    {
        return CreateInstance(
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true);
    }
}