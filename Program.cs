using System.CommandLine;
using System.Net.Http.Json;
using System.Text.Json;
using ZhConverterRequester;

Command serviceInfoCommand = new("service-info", Descriptions.ServiceInfo);
serviceInfoCommand.Aliases.Add("info");
foreach (var option in OptionProvider.InfoOptions)
    serviceInfoCommand.Options.Add(option);

RootCommand rootCommand = new(Descriptions.Application);
rootCommand.Subcommands.Add(serviceInfoCommand);
rootCommand.Aliases.Add("convert");
foreach (var option in OptionProvider.Options)
    rootCommand.Options.Add(option);

rootCommand.SetAction(async r =>
{
    var text = r.GetValue<string>("--Text");
    if (string.IsNullOrWhiteSpace(text))
        if (r.GetValue<FileInfo>("--InputFile") is FileInfo inputFile)
            if (inputFile.Exists)
            {
                text = File.ReadAllText(inputFile.FullName);
                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("文件为空。");
                    return 1;
                }
            }
            else
            {
                Console.WriteLine("文件不存在");
                return 1;
            }
        else
        {
            Console.WriteLine("输入为空。");
            return 1;
        }

    if (r.GetValue<bool?>("--RepeatInput") ?? false)
        Log("Input", text);

    HttpClient client = new();
    var response = await client.PostAsJsonAsync(OptionProvider.ConvertUri, new Con() { text = text, converter = r.GetValue<string>("--Converter")! });
    var responseObj = JsonSerializer.Deserialize<Response>(response.Content.ReadAsStream(), OptionProvider.JsonSerializerOptions);
    if (responseObj == null)
    {
        Console.WriteLine("繁化姬返回数据为空。");
        return 2;
    }
    if (r.GetValue<bool?>("--ShowDetail") ?? responseObj.Code != 0)
        LogResponse(responseObj);

    ConvertData data = JsonSerializer.Deserialize<ConvertData>(responseObj.Data, OptionProvider.JsonSerializerOptions);
    if (r.GetValue<bool?>("--ShowDetail") ?? false)
    {
        Log("Converter", data.Converter);
        Log("JpTextStyles", string.Join(" | ", data.JpTextStyles ?? ["Null"]));
        Log("UsedModules", string.Join(" | ", data.UsedModules ?? ["Null"]));
        Log("TextFormat", data.TextFormat);
    }

    var output = (r.GetValue<bool?>("--OutputRaw") ?? false) ? await response.Content.ReadAsStringAsync() : data.Text;

    if (r.GetValue<bool?>("--OutputConsole") ?? (r.GetValue<FileInfo?>("--OutputFile") == null || output == null || output.Length < 100))
    {
        Log("Output", output);
    }
    if (r.GetValue<FileInfo?>("--OutputFile") is FileInfo outputFile)
    {
        WriteFile(outputFile, output);
    }

    return 0;
});

serviceInfoCommand.SetAction(async r =>
{
    HttpClient client = new();
    var response = await client.GetStringAsync(OptionProvider.InfoUri);
    var responseObj = JsonSerializer.Deserialize<Response>(response, OptionProvider.JsonSerializerOptions);
    if (responseObj == null)
    {
        Console.WriteLine("繁化姬返回数据为空。");
        return 2;
    }
    if (r.GetValue<bool?>("--ShowDetail") ?? responseObj.Code != 0)
        LogResponse(responseObj);

    var output = ((JsonElement?)responseObj.Data)?.ToString();

    if (r.GetValue<bool?>("--OutputConsole") ?? (r.GetValue<FileInfo?>("--OutputFile") == null || output == null || output.Length < 100))
    {
        Console.WriteLine("Info");
        Console.WriteLine(output?.Replace("\n    ", "\n"));
    }
    if (r.GetValue<FileInfo?>("--OutputFile") is FileInfo outputFile)
        WriteFile(outputFile, output);

    return 0;
});

return rootCommand.Parse(args).Invoke();

static void Log(string prop, string? content, ConsoleColor? color = null)
{
    content ??= "Null";
    if (content.Length == 0) content = "Empty";

    if (color != null)
        Console.ForegroundColor = (ConsoleColor)color;

    Console.WriteLine(prop.PadRight(16) + content);

    Console.ResetColor();
}
static void LogResponse(Response response)
{
    Log("Code", response.Code.ToString());
    Log("Message", response.Msg);
    Log("ExecutionTime", $"{response.ExecTime * 1000} ms");
    Console.WriteLine("Revisions");
    Log("  Build", response.Revisions?.Build);
    Log("  Message", response.Revisions?.Msg);
    Log("  Time", response.Revisions?.DateTime.ToString());
}

static void WriteFile(FileInfo file, string? content)
{
    Log("OutputFile", file.FullName);
    using var sw = File.CreateText(file.FullName);
    sw.Write(content);
}
