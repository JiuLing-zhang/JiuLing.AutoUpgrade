<p align="center">
<a href="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade" target="_blank"><img src="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/raw/main/docs/resources/images/logo.png" ></a>
</p>

<div align="center">

![](https://img.shields.io/github/license/JiuLing-zhang/JiuLing.AutoUpgrade)
![](https://img.shields.io/github/actions/workflow/status/JiuLing-zhang/JiuLing.AutoUpgrade/build.yml)
[![](https://img.shields.io/nuget/v/JiuLing.AutoUpgrade)](https://www.nuget.org/packages/JiuLing.AutoUpgrade)
[![](https://img.shields.io/github/v/release/JiuLing-zhang/JiuLing.AutoUpgrade)](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases)

</div>

一个简单、易用的自动更新组件。 👉👉[English Version](./README_en.md)    

<div align="center">
<img src="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/raw/main/docs/resources/images/demo1.png" width="40%">
<img src="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/raw/main/docs/resources/images/demo2.png" width="40%">
</div>

## 介绍  

更新程序的核心程序是基于 `.NET Framework 4.7` 开发的 `x64` 格式的程序，所以使用此组件之前，请先确保客户端环境能够运行该程序。  

\- 🔥 组件支持自更新  
\- 🌈 支持 `HTTP`  
\- 🌀 支持 `FTP`  
\- ⭐ 版本过期后禁止运行

## 运行方式  

1. 🕐 去服务端下载更新包（如果有更新可用）  
2. 🕑 关闭主程序  
3. 🕒 将更新包的内容解压后复制到主程序根目录
4. 🕓 重启主程序  

**🎈 检查更新时，如果指定了最小运行版本，并且主程序版本低于最小版本，那么自动更新程序将不允许跳过本次更新，不更新直接关闭自动更新程序时，同时也会关闭主程序**  

**🎉 更新包仅支持 `.zip` 压缩包。**  

## 安装  
🟢 通过 [`Nuget`](https://www.nuget.org/packages/JiuLing.AutoUpgrade) 安装。  
🟢 通过 [`Release`](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases) 下载。  

## 使用  
1️⃣ 导入命名空间  
```C#
using JiuLing.AutoUpgrade.Shell;
```
2️⃣ 创建更新  
```C#
var app = AutoUpgradeFactory.Create();
```
3️⃣ 选择更新方式  
```C#
//Http 方式更新
app.UseHttpMode("https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json");

//Ftp 方式更新
app.UseFtpMode("upgradePath", "userName", "password");
```
4️⃣ 启动  
```C#
app.Run();
// or
await app.RunAsync();
```

> 🫧 链式写法
```C#
AutoUpgradeFactory.Create().UseHttpMode("https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json").Run();
```

**💠 自动更新接口需要返回如下格式的 `json` 内容。**  

- Version: ❗[必须] 最新的版本号  
- DownloadUrl: ❗[必须] 程序的下载路径  
- FileLength: 文件大小，字节  
- MinVersion: 程序运行的最低版本号，低于此版本将无法运行  
- Log: 更新日志  
- CreateTime: 时间
- SignType: 文件校验的签名方式  
- SignValue: 文件校验的签名值  

```json
{
    "Version": "1.2.0",
    "DownloadUrl": "xxxxx/update.zip",
    "FileLength": 1887436,
    "MinVersion": "1.1.0",
    "Log": "1、修复了若干bug。2、新增了若干需求。",
    "CreateTime": "2022-01-16 12:12:12",
    "SignType": "MD5",
    "SignValue": "f42c6cb229a0a1237c9945448342d59e"
}
```

## 🔨 高级设置  
⚡ 设置图标   

```C#
    app.SetUpgrade(config =>
    {
        config.IconPath = "icon.ico";
        // or
        config.IconPath = @"C:\icon.ico";
    });
```

🌀 检查更新时的请求超时时间（默认 5 秒）  

```C#
    app.SetUpgrade(config =>
    {
        config.TimeoutSecond = 60;
    });
```

🎁 是否在后台进行更新检查（默认为否）  

```C#
    app.SetUpgrade(config =>
    {
        config.IsBackgroundCheck = true;
    });
```

⚽ 对下载的文件启用签名校验，支持 `MD5` 和 `SHA1` 两种方式（默认为不启用）  

```C#
    app.SetUpgrade(config =>
    {
        config.IsCheckSign = true;
    });
```

🎲 设置主题，支持“跟随系统”、“浅色主题”、“深色主题”（默认为跟随系统）  

```C#
    app.SetUpgrade(config =>
    {
        config.Theme = Shared.ThemeEnum.System;
        // config.Theme = Shared.ThemeEnum.Light;
        // config.Theme = Shared.ThemeEnum.Dark;
    });
```

💎 设置多语言，支持中文、英文（默认为中文）。  

```C#
    app.SetUpgrade(config =>
    {
        config.Lang = "zh";
        // config.Lang = "en";
    });
```

📌 设置版本号显示格式。  

```C#
    app.SetUpgrade(config =>
    {
        config.VersionFormat = Shell.Enums.VersionFormatEnum.Major; // 1
        // config.VersionFormat = Shell.Enums.VersionFormatEnum.MajorMinor; // 1.2
        // config.VersionFormat = Shell.Enums.VersionFormatEnum.MajorMinorBuild; // 1.2.3
        // config.VersionFormat = Shell.Enums.VersionFormatEnum.MajorMinorBuildRevision; // 1.2.3.4
    });
```

## 项目说明  

```Text
src
  ├─JiuLing.AutoUpgrade             核心程序
  ├─JiuLing.AutoUpgrade.Shell       启动程序，用来启动核心更新程序  
  │  └─Resources                    通过动态资源的形式加载核心程序，使得核心程序可以实现自身更新。项目编译前，会先从Librarys.tmp文件夹拷贝核心程序
  │     └─JiuLing.AutoUpgrade.exe
  ├─JiuLing.AutoUpgrade.Shared      核心程序和启动程序所共享的代码片段
  ├─JiuLing.AutoUpgrade.Test        测试程序
  │  ├─JiuLing.AutoUpgrade.Test.csproj
  │  ├─UpgradePackage1.2.0.zip
  │  └─测试环境配置说明.txt
  ├─Librarys.tmp                    临时目录，核心程序编译完成后将自身发布到该目录
  │  └─JiuLing.AutoUpgrade.exe
  └─JiuLing.AutoUpgrade.sln         项目解决方案
```

## License
MIT License