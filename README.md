# 繁化姬 Console

查看所有选项：

```
.\ZhConvertRequester.exe --help
```

选项行为参见：<https://docs.zhconvert.org/api/convert/>

## 用例

转换文本至台湾
```pwsh
.\ZhConvertRequester.exe -c Taiwan -t "内存不足！"
```

转换文件至大陆、显示请求细节、并写入结果至文件
```pwsh
.\ZhConvertRequester.exe -c China -i D:\S1\EP1.tc.ass -o D:\S1\EP1.sc.ass --detail
```

转换文件夹内所有 `.ass` 字幕至简体、使用文本清理、并写入结果至文件
```pwsh
Get-ChildItem -Path D:\S1 -File -Filter *.ass | foreach { .\ZhConvertRequester.exe -c Simplified -i $_ -o "$_.sc.ass" --clean }
```
