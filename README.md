![](https://img.shields.io/github/license/JiuLing-zhang/JiuLing.AutoUpgrade)
![](https://img.shields.io/github/workflow/status/JiuLing-zhang/JiuLing.AutoUpgrade/Build)
[![](https://img.shields.io/nuget/v/JiuLing.AutoUpgrade)](https://www.nuget.org/packages/JiuLing.AutoUpgrade)
[![](https://img.shields.io/github/v/release/JiuLing-zhang/JiuLing.AutoUpgrade)](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases)  

## :one:.介绍
`JiuLing.AutoUpgrade` 是一个简单、易用的自动更新组件。  

更新程序的核心程序是基于 `.NET Framework 4.7` 开发的 `x64` 格式的程序，所以使用此组件之前，请先确保客户端环境能够运行该程序。  

特点：相比较普通的自动更新程序，`JiuLing.AutoUpgrade` 自身也可以完成自更新操作。

支持 `Http` 和 `Ftp` 两种更新方式，更新包仅支持 `.zip` 压缩包。组件运行后，会去服务端下载自动更新的压缩包，完成后关闭主程序，将压缩包的内容解压后复制到程序根目录。  

**检查更新时，如果指定了最小运行版本，并且主程序版本低于最小版本，那么自动更新程序将不允许跳过本次更新，不更新直接关闭自动更新程序时，同时也会关闭主程序**  

![main1.png](https://s2.loli.net/2022/01/21/CoOMVHLTvQAPu5X.png)  
![main2.png](https://s2.loli.net/2022/01/21/xC6jka4vGdgptTq.png)  
![download.png](https://s2.loli.net/2022/01/21/94nGMBNJpQUzYTR.png)  

## :two:.安装  
* 通过 `Nuget` 直接安装。👉👉👉[`JiuLing.AutoUpgrade`](https://www.nuget.org/packages/JiuLing.AutoUpgrade)  
* 下载最新的 `Release` 版本自己引用到项目。👉👉👉[`下载`](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases)  

## :three:.使用  
1. 导入命名空间 `using JiuLing.AutoUpgrade.Shell;`
2. 启动更新
```C#
//Http 方式更新
var app = AutoUpgradeFactory.Create();
app.UseHttpMode("https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json")
    .Run();

//Ftp 方式更新
var app = AutoUpgradeFactory.Create();
app.UseFtpMode("upgradePath", "userName", "password")
    .Run();
```
***更新信息需要返回如下格式的 `json` 内容。***  
```json
{
    "Version":"最新的版本号（必须返回）",
    "MinVersion":"程序运行的最低版本号，低于此版本将无法运行",
    "DownloadUrl":"程序的下载路径（必须返回）",
    "Log":"更新日志",
    "CreateTime":"时间"
}
```
```json
{
    "Version":"1.2.0",
    "MinVersion":"1.1.0",
    "DownloadUrl":"demo.com/update.zip",
    "Log":"1、修复了若干bug。2、新增了若干需求。",
    "CreateTime":"2022-01-16 12:12:12"
}
```

## :four:.项目说明  

|-- root  
    |-- JiuLing.AutoUpgrade.sln  项目解决方案  
    |-- Librarys.tmp             临时目录，核心程序编译完成后将自身发布到该目录  
    |   |-- JiuLing.AutoUpgrade.exe  
    |-- src  
    |   |-- JiuLing.AutoUpgrade  核心程序  
    |   |   |-- lib              项目需要的dll，通过本地目录引用，然后以嵌入式资源打包，使得最终只生成一个.exe的主程序  
    |   |   |   |-- Newtonsoft.Json.dll  
    |   |   |   |-- System.IO.Compression.ZipFile.dll  
    |   |-- JiuLing.AutoUpgrade.Shell      启动程序，用来启动核心更新程序  
    |       |-- Resources                  通过动态资源的形式加载核心程序，使得核心程序可以实现自身更新。项目编译前，会先从Librarys.tmp文件夹拷贝核心程序。    
    |       |   |-- JiuLing.AutoUpgrade.exe  
    |-- test                               测试程序
        |-- JiuLing.AutoUpgrade.Test.csproj  
        |-- UpgradePackage1.2.0.zip  
        |-- 测试环境配置说明.txt  

## :five:.License
MIT License