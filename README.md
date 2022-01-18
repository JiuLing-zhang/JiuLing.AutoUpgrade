# AutoUpgrade
一个`.net 6`写的自动更新组件，目前处于开发中。  

# 使用  
该程序目前仅支持`.zip`压缩包形式的自动更新。
## 配置：
将自动更新程序放入程序的目录，填写配置文件`AutoUpgrade.config.json`。自动更新程序运行后会自动去配置的地址检查是否有可用更新，如果发现新版本，下载后自动解压到当前路径，如果文件存在，则覆盖。    

```json
{
  "MainProcessName": "主进程名称，更新时会结束该进程，更新完成后再自动启动。",
  "UpgradeUrl": "检查自动更新的地址"
}
```
例如：  
```json
{
  "MainProcessName": "AutoUpgrade.Test",
  "UpgradeUrl": "https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json"
}
```

自动更新检查接口（`UpgradeUrl`）需要返回如下格式的`json`内容
```json
{
    "Version":"最新的版本号（必须返回）",
    "MinVersion":"程序运行的最低版本号，低于此版本将无法运行",
    "DownloadUrl":"程序的下载路径（必须返回）",
    "Log":"更新日志",
    "CreateTime":"时间"
}
```
例如：  
```json
{
    "Version":"1.2.0",
    "MinVersion":"1.1.0",
    "DownloadUrl":"demo.com/update.zip",
    "Log":"1、修复了若干bug。2、新增了若干需求。",
    "CreateTime":"2022-01-16 12:12:12"
}
```
## 运行：
直接启动`AutoUpgrade.exe`进程即可。  
```C#
Process.Start("AutoUpgrade.exe");
```