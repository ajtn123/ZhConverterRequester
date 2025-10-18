namespace ZhConverterRequester;

public static class Descriptions
{
    public const string Application = "繁化姬 API 请求器";
    public const string ServiceInfo = "獲取繁化姬的服務設定。";

    public const string InputFile = "將要被轉換的文本文件。";
    public const string RepeatInput = "是否复述输入文本。";
    public const string OutputFile = "保存结果的文本文件的路径。";
    public const string OutputConsole = "是否在 Console 输出结果。";
    public const string OutputRaw = "是否输出原始 JSON。";
    public const string ShowDetail = "是否显示详细信息（执行时间、繁化姬版本號等）。";

    public const string Text = "將要被轉換的文字。";
    public const string Converter = "所要使用的轉換器。有 Simplified（簡體化）、Traditional（繁體化）、China（中國化）、Hongkong（香港化）、Taiwan（台灣化）、Pinyin（拼音化）、Bopomofo（注音化）、Mars（火星化）、WikiSimplified（維基簡體化）、WikiTraditional（維基繁體化）。";
    public const string IgnoreTextStyles = "由那些不希望被繁化姬處理的 \"樣式\" 以逗號分隔所組成的字串。通常用於保護特效字幕不被轉換，例如字幕組的特效字幕若是以 OPJP 與 OPCN 作為樣式名。可以設定 \"OPJP,OPCN\" 來作保護。";
    public const string JpTextStyles = "告訴繁化姬哪些樣式要當作日文處理（預設為伺服器端自動猜測）。若要自行設定，則必須另外再加入 *noAutoJpTextStyles 這個樣式。所有樣式以逗號分隔組成字串，例如： \"OPJP,EDJP,*noAutoJpTextStyles\" 表示不讓伺服器自動猜測，並指定 OPJP 與 EDJP 為日文樣式。";
    public const string JpStyleConversionStrategy = "對於日文樣式該如何處理。\"none\" 表示 無（當成中文處理） 、 \"protect\" 表示 保護 、 \"protectOnlySameOrigin\" 表示 僅保護原文與日文相同的字 、 \"fix\" 表示 修正 。";
    public const string JpTextConversionStrategy = "對於繁化姬自己發現的日文區域該如何處理。 \"none\" 表示 無（當成中文處理） 、 \"protect\" 表示 保護 、 \"protectOnlySameOrigin\" 表示 僅保護原文與日文相同的字 、 \"fix\" 表示 修正 。";
    public const string Modules = "強制設定模組啟用/停用。-1 / 0 / 1 分別表示 自動 / 停用 / 啟用。字串使用 JSON 格式編碼。使用 * 可以先設定所有模組的狀態。例如：{\"*\":0,\"Naruto\":1,\"Typo\":1} 表示停用所有模組，但啟用 火影忍者 與 錯別字修正 模組。";
    public const string UserPostReplace = "轉換後再進行的額外取代。格式為 \"搜尋1=取代1\\n搜尋2=取代2\\n...\"。搜尋1 會在轉換後再被取代為 取代1。";
    public const string UserPreReplace = "轉換前先進行的額外取代。格式為 \"搜尋1=取代1\\n搜尋2=取代2\\n...\"。搜尋1 會在轉換前先被取代為 取代1。";
    public const string UserProtectReplace = "保護字詞不被繁化姬修改。格式為 \"保護1\\n保護2\\n...\"。保護1、保護2 等字詞將不會被繁化姬修改。";
    public const string DiffCharLevel = "是否使用字元級別的差異比較（否則為行級別），這將會使回應時間變長。";
    public const string DiffContextLines = "所輸出的結果要包含多少行上下文。可以是 0~4 之間的整數。";
    public const string DiffEnable = "是否要啟用差異比較。";
    public const string DiffIgnoreCase = "是否要忽略英文大小寫的差異。";
    public const string DiffIgnoreWhiteSpaces = "是否要忽略空格的差異。";
    public const string DiffTemplate = "所要使用的輸出模板。可選的值有：Inline、SideBySide、Unified、Context、JsonHtml 以及 JsonText。";
    public const string CleanUpText = "根據所偵測到的文本格式做出對應的文本清理。例如 ASS 字幕 的編輯器訊息、空白的對話等等，將會被移除。";
    public const string EnsureNewlineAtEof = "確保輸出的文本結尾處有一個且只有一個換行符。";
    public const string TranslateTabsToSpaces = "轉換每行開頭的 Tab 為數個空格。此值可以是 -1~8 之間的整數。-1 表示不轉換；0 表示移除開頭 Tab。1~8 表示轉換為數個空白。";
    public const string TrimTrailingWhiteSpaces = "移除每行結尾的多餘空格。";
    public const string UnifyLeadingHyphen = "將區分說話人用的連字號統一為半形減號。";
}
