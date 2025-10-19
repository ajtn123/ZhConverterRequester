using System.CommandLine;
using System.Text.Json;

namespace ZhConverterRequester;

public static class OptionProvider
{
    public static JsonSerializerOptions JsonSerializerOptions { get; } = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public static Option[] Options => [
        new Option<FileInfo?>("--InputFile", "-i") { Description = Descriptions.InputFile },
        new Option<bool?>("--RepeatInput") { Description = Descriptions.RepeatInput },
        new Option<FileInfo?>("--OutputFile", "-o") { Description = Descriptions.OutputFile },
        new Option<bool?>("--OutputConsole", "--console") { Description = Descriptions.OutputConsole },
        new Option<bool?>("--OutputRaw", "--raw") { Description = Descriptions.OutputRaw },
        new Option<bool?>("--ShowDetail") { Description = Descriptions.ShowDetail },

        new Option<string>("--Text", "-t") { Description = Descriptions.Text },
        new Option<string>("--Converter", "-c") { Description = Descriptions.Converter, Required = true },
        new Option<string>("--IgnoreTextStyles") { Description = Descriptions.IgnoreTextStyles },
        new Option<string>("--JpTextStyles") { Description = Descriptions.JpTextStyles },
        new Option<string>("--JpStyleConversionStrategy") { Description = Descriptions.JpStyleConversionStrategy },
        new Option<string>("--JpTextConversionStrategy") { Description = Descriptions.JpTextConversionStrategy },
        new Option<string>("--Modules") { Description = Descriptions.Modules },
        new Option<string>("--UserPostReplace") { Description = Descriptions.UserPostReplace },
        new Option<string>("--UserPreReplace") { Description = Descriptions.UserPreReplace },
        new Option<string>("--UserProtectReplace") { Description = Descriptions.UserProtectReplace },
        new Option<bool?>("--DiffCharLevel") { Description = Descriptions.DiffCharLevel },
        new Option<int?>("--DiffContextLines") { Description = Descriptions.DiffContextLines },
        new Option<bool?>("--DiffEnable", "--diff") { Description = Descriptions.DiffEnable },
        new Option<bool?>("--DiffIgnoreCase") { Description = Descriptions.DiffIgnoreCase },
        new Option<bool?>("--DiffIgnoreWhiteSpaces") { Description = Descriptions.DiffIgnoreWhiteSpaces },
        new Option<string>("--DiffTemplate") { Description = Descriptions.DiffTemplate },
        new Option<bool?>("--CleanUpText", "--clean") { Description = Descriptions.CleanUpText },
        new Option<bool?>("--EnsureNewlineAtEof") { Description = Descriptions.EnsureNewlineAtEof },
        new Option<int?>("--TranslateTabsToSpaces") { Description = Descriptions.TranslateTabsToSpaces },
        new Option<bool?>("--TrimTrailingWhiteSpaces") { Description = Descriptions.TrimTrailingWhiteSpaces },
        new Option<bool?>("--UnifyLeadingHyphen") { Description = Descriptions.UnifyLeadingHyphen },
    ];

    public static Option[] InfoOptions => [
        new Option<FileInfo?>("--OutputFile", "-o") { Description = Descriptions.OutputFile },
        new Option<bool?>("--OutputConsole", "--console") { Description = Descriptions.OutputConsole },
        new Option<bool?>("--ShowDetail") { Description = Descriptions.ShowDetail },
    ];

    public static Uri ConvertUri => new($"https://api.zhconvert.org/convert");
    public static Uri InfoUri => new($"https://api.zhconvert.org/service-info?prettify=1");
}
