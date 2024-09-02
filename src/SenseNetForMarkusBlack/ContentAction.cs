namespace SenseNetForMarkusBlack;

internal class ContentAction
{
    public string Name { get; set; }
    public string OpId { get; set; }
    public string DisplayName { get; set; }
    public int Index { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
    public bool IsODataAction { get; set; }
    public string[] ActionParameters { get; set; } = Array.Empty<string>();
    public string Scenario { get; set; }
    public bool Forbidden { get; set; }
}