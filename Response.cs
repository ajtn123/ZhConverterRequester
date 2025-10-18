namespace ZhConverterRequester;

public class Response
{
    public int? Code { get; set; }
    public dynamic? Data { get; set; }
    public string? Msg { get; set; }
    public Revisions? Revisions { get; set; }
    public double? ExecTime { get; set; }

    public TimeSpan? ExecutionTime => ExecTime is double et ? TimeSpan.FromSeconds(et) : null;
}

public class Revisions
{
    public string? Build { get; set; }
    public string? Msg { get; set; }
    public long? Time { get; set; }

    public DateTimeOffset? DateTime => Time is long time ? DateTimeOffset.FromUnixTimeSeconds(time).ToLocalTime() : null;
}

public class ConvertData
{
    public string? Converter { get; set; }
    public string? Text { get; set; }
    public string? Diff { get; set; }
    public string[]? UsedModules { get; set; }
    public string[]? JpTextStyles { get; set; }
    public string? TextFormat { get; set; }
}
