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

**🤖 [Upgrade from versions prior to v2.1](./v2.1_to_v2.2.md)**  

<div align="center">
<img src="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/raw/main/docs/resources/images/demo1.png" width="40%">
<img src="https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/raw/main/docs/resources/images/demo2.png" width="40%">
</div>

## About  

The core program is developed using `.NET Framework 4.7` (`x64`). Before using this component, make sure the client can run the program.  

\- 🔥 Component supports self-update
\- 🌈 Supports HTTP
\- 🌀 Supports FTP
\- ⚡ Supports GitHub Release
\- ⭐ Prohibits running after version expiration

## How to Run  

1. 🕐 Download the update package from the server (if updates are available)
2. 🕑 Close the main application
3. 🕒 Extract the update package and copy the contents to the main application's root directory
4. 🕓 Restart the main application

**🎈If the minimum version is specified and the main program version is lower than the minimum version, the automatic update program will not be allowed to skip this update. If the automatic update program is closed directly without updating, the main program will also be closed.**  

**🎉 The update package only supports `.zip` compressed packages**


## Install  

🟢 From [`Nuget`](https://www.nuget.org/packages/JiuLing.AutoUpgrade)  
🟢 From [`Release`](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases)  

## Getting Started  
### 1️⃣ Import namespace  
```C#
using JiuLing.AutoUpgrade.Shell;
```
### 2️⃣ Create upgrade app  
```C#
// HTTP model
IUpgradeApp app = UpgradeFactory.CreateHttpApp("url");

// FTP model
IUpgradeApp app = UpgradeFactory.CreateFtpApp("path", "username", "password");

// GitHub Release model
// assetName: update.zip
IUpgradeApp app = UpgradeFactory.CreateGitHubApp("owner", "repo", "assetName");
```
### 3️⃣ Do update  
```C#
app.Run();
// or
await app.RunAsync();
```
> 🫧 Advanced
```C#
await UpgradeFactory.CreateHttpApp("url").RunAsync();
```

### 4️⃣ Server configuration  
* `HTTP` and `FTP` model  
    **💠 The update API should return the following json format:**  

    > Feel free to use either PascalCase or camelCase for JSON responses

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

* `GitHub Release` model  
    - Version: `Release Name`  
    - DownloadUrl: Get the file URL matching the `Assets Name` in the `Release`  

## 🔨 Advanced Settings  

```C#
await UpgradeFactory.CreateHttpApp("url")
    .SetUpgrade(builder =>
    {
        builder.WithIcon("path")
        .WithTimeout(60)
        .WithBackgroundCheck(true)
        .WithSignCheck(true)
        .WithTheme(ThemeEnum.System)
        .WithLang("zh")
        .WithVersionFormat(VersionFormatEnum.MajorMinorBuild);
    })
    .RunAsync();
```

⚡ Set icon  

```C#
setting.WithIcon("icon.ico");
```

🌀 Request timeout when checking for updates (default: 5 seconds)  

```C#
setting.WithTimeout(60);
```

🎁 Whether to check for updates in the background (default: `false`)  

```C#
setting.WithBackgroundCheck(true);
```

⚽ Enable signature verification, supporting both `MD5` and `SHA1` methods.  

```C#
setting.WithSignCheck(true);
```

🎲 Set the dark theme (default: follow the operating system).  

```C#
setting.WithTheme(ThemeEnum.System);
// setting.WithTheme(ThemeEnum.Light);
// setting.WithTheme(ThemeEnum.Dark);
```

💎 Globalization (default: zh) (Only supports zh、en)  

```C#
setting.WithLang("zh");
// setting.WithLang("en");
```

📌 Set the version number display format.  

```C#
setting.WithVersionFormat(VersionFormatEnum.MajorMinorBuildRevision);
// setting.WithVersionFormat(VersionFormatEnum.MajorMinorBuild);
// setting.WithVersionFormat(VersionFormatEnum.MajorMinor);
// setting.WithVersionFormat(VersionFormatEnum.Major);
```

## License
MIT License