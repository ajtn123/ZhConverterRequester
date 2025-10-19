using System.CommandLine;

namespace ZhConverterRequester;

public class Con(ParseResult result)
{
#pragma warning disable IDE1006 // 命名样式
    public required string text { get; set; }
    public string? converter { get; set; } = result.GetValue<string>("--Converter");
    public string? ignoreTextStyles { get; set; } = result.GetValue<string>("--IgnoreTextStyles");
    public string? jpTextStyles { get; set; } = result.GetValue<string>("--JpTextStyles");
    public string? jpStyleConversionStrategy { get; set; } = result.GetValue<string>("--JpStyleConversionStrategy");
    public string? jpTextConversionStrategy { get; set; } = result.GetValue<string>("--JpTextConversionStrategy");
    public string? modules { get; set; } = result.GetValue<string>("--Modules");
    public string? userPostReplace { get; set; } = result.GetValue<string>("--UserPostReplace");
    public string? userPreReplace { get; set; } = result.GetValue<string>("--UserPreReplace");
    public string? userProtectReplace { get; set; } = result.GetValue<string>("--UserProtectReplace");
    public bool? diffCharLevel { get; set; } = result.GetValue<bool?>("--DiffCharLevel");
    public int? diffContextLines { get; set; } = result.GetValue<int?>("--DiffContextLines");
    public bool? diffEnable { get; set; } = result.GetValue<bool?>("--DiffEnable");
    public bool? diffIgnoreCase { get; set; } = result.GetValue<bool?>("--DiffIgnoreCase");
    public bool? diffIgnoreWhiteSpaces { get; set; } = result.GetValue<bool?>("--DiffIgnoreWhiteSpaces");
    public string? diffTemplate { get; set; } = result.GetValue<string>("--DiffTemplate");
    public bool? cleanUpText { get; set; } = result.GetValue<bool?>("--CleanUpText");
    public bool? ensureNewlineAtEof { get; set; } = result.GetValue<bool?>("--EnsureNewlineAtEof");
    public int? translateTabsToSpaces { get; set; } = result.GetValue<int?>("--TranslateTabsToSpaces");
    public bool? trimTrailingWhiteSpaces { get; set; } = result.GetValue<bool?>("--TrimTrailingWhiteSpaces");
    public bool? unifyLeadingHyphen { get; set; } = result.GetValue<bool?>("--UnifyLeadingHyphen");
#pragma warning restore IDE1006 // 命名样式
}