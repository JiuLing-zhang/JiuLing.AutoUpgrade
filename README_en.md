<p align="center">
<a href="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade" target="_blank"><img src="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/raw/main/docs/resources/images/logo.png" ></a>
</p>

<div align="center">

![](https://img.shields.io/github/license/JiuLing-zhang/JiuLing.AutoUpgrade)
![](https://img.shields.io/github/actions/workflow/status/JiuLing-zhang/JiuLing.AutoUpgrade/build.yml)
[![](https://img.shields.io/nuget/v/JiuLing.AutoUpgrade)](https://www.nuget.org/packages/JiuLing.AutoUpgrade)
[![](https://img.shields.io/github/v/release/JiuLing-zhang/JiuLing.AutoUpgrade)](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases)

</div>

A simple and easy-to-use automatic update component。 👉👉[中文版](./README.md)  

<div align="center">
<img src="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/raw/main/docs/resources/images/demo1.png" width="40%">
<img src="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/raw/main/docs/resources/images/demo2.png" width="40%">
</div>

## About  

The core program is developed using `.NET Framework 4.7` (`x64`). Before using this component, make sure the client can run the program.  

\- 🔥 Component supports self-update
\- 🌈 Supports HTTP
\- 🌀 Supports FTP
\- ⭐ Prohibits running after version expiration

## How to Run  

1. 🕐 Download the update package from the server (if updates are available)
2. 🕑 Close the main application
3. 🕒 Extract the update package and copy the contents to the main application’s root directory
4. 🕓 Restart the main application

**🎈If the minimum version is specified and the main program version is lower than the minimum version, the automatic update program will not be allowed to skip this update. If the automatic update program is closed directly without updating, the main program will also be closed.**  

**🎉 The update package only supports `.zip` compressed packages**


## Install  

🟢 From [`Nuget`](https://www.nuget.org/packages/JiuLing.AutoUpgrade)  
🟢 From [`Release`](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases)  

## Getting Started  
1️⃣ Import namespace  
```C#
using JiuLing.AutoUpgrade.Shell;
```
2️⃣ Create app  
```C#
var app = AutoUpgradeFactory.Create();
```
3️⃣ Config update Type  
```C#
//Http 方式更新
app.UseHttpMode("https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json");

//Ftp 方式更新
app.UseFtpMode("upgradePath", "userName", "password");
```
4️⃣ Do update  
```C#
app.Run();
// or
await app.RunAsync();
```
> 🫧 Advanced
```C#
AutoUpgradeFactory.Create().UseHttpMode("https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json").Run();
```

**💠 The update API should return the following json format:**  

- Version: ❗[Required] The latest version number  
- DownloadUrl: ❗[Required] The download URL of the application  
- FileLength: File length (byte)  
- MinVersion: The minimum version required for the application to run; versions below this will not be able to run  
- Log: Update log  
- CreateTime: Timestamp  
- SignType: Signature type used for file verification  
- SignValue: Signature value for file verification  

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

## 🔨 Advanced Config  
⚡ Set icon  

```C#
    app.SetUpgrade(config =>
    {
        config.IconPath = "icon.ico";
        // or
        config.IconPath = @"C:\icon.ico";
    });
```

🌀 Request timeout when checking for updates (default: 5 seconds)  

```C#
    app.SetUpgrade(config =>
    {
        config.TimeoutSecond = 60;
    });
```

🎁 Whether to check for updates in the background (default: `false`)  

```C#
    app.SetUpgrade(config =>
    {
        config.IsBackgroundCheck = true;
    });
```

⚽ Enable signature verification, supporting both `MD5` and `SHA1` methods.  

```C#
    app.SetUpgrade(config =>
    {
        config.IsCheckSign = true;
    });
```

🎲 Set the dark theme (default: follow the operating system).  

```C#
    app.SetUpgrade(config =>
    {
        config.Theme = Shared.ThemeEnum.System;
        // config.Theme = Shared.ThemeEnum.Light;
        // config.Theme = Shared.ThemeEnum.Dark;
    });
```

💎 Globalization (default: zh) (Only supports zh、en)  

```C#
    app.SetUpgrade(config =>
    {
        config.Lang = "zh";
        // config.Lang = "en";
    });
```

📌 Set the version number display format.  

```C#
    app.SetUpgrade(config =>
    {
        config.VersionFormat = Shell.Enums.VersionFormatEnum.Major; // 1
        // config.VersionFormat = Shell.Enums.VersionFormatEnum.MajorMinor; // 1.2
        // config.VersionFormat = Shell.Enums.VersionFormatEnum.MajorMinorBuild; // 1.2.3
        // config.VersionFormat = Shell.Enums.VersionFormatEnum.MajorMinorBuildRevision; // 1.2.3.4
    });
```

## License
MIT License