![](https://img.shields.io/github/license/JiuLing-zhang/JiuLing.AutoUpgrade)
![](https://img.shields.io/github/workflow/status/JiuLing-zhang/JiuLing.AutoUpgrade/Publish)
[![](https://img.shields.io/nuget/v/JiuLing.AutoUpgrade)](https://www.nuget.org/packages/JiuLing.AutoUpgrade)
[![](https://img.shields.io/github/v/release/JiuLing-zhang/JiuLing.AutoUpgrade)](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases)  

## :one:.介绍
`JiuLing.AutoUpgrade`是一个`.net 6`写的自动更新组件。  

特点：相比较普通的自动更新程序，`JiuLing.AutoUpgrade`自身也可以完成自更新操作。

支持`Http`和~~`Ftp（开发中）`~~两种更新方式，更新包仅支持`.zip`压缩包。组件运行后，会去服务端下载自动更新的压缩包，完成后关闭主程序，将压缩包的内容解压后复制到程序根目录。  

**检查更新时，如果指定了最小运行版本，并且主程序版本低于最小版本，那么自动更新程序将不允许跳过本次更新，不更新直接关闭自动更新程序时，同时也会关闭主程序**  

![main1.png](https://s2.loli.net/2022/01/21/CoOMVHLTvQAPu5X.png)  
![main2.png](https://s2.loli.net/2022/01/21/xC6jka4vGdgptTq.png)  
![download.png](https://s2.loli.net/2022/01/21/94nGMBNJpQUzYTR.png)  

## :two:.安装  
* 通过`Nuget`直接安装。👉👉👉[`JiuLing.AutoUpgrade`](https://www.nuget.org/packages/JiuLing.AutoUpgrade)  
* 下载最新的`Release`版本自己引用到项目。👉👉👉[`下载`](https://github.com/JiuLing-zhang/JiuLing.AutoUpgrade/releases)  

## :three:.使用  
1. 导入命名空间`using JiuLing.AutoUpgrade.Shell;`
2. 启动更新
```C#
//Http方式更新
var app = AutoUpgradeFactory.Create();
app.UseHttpMode("https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json")
    .Run();

//Ftp方式更新
var app = AutoUpgradeFactory.Create();
app.UseFtpMode("userName", "password", "upgradePath")
    .Run();
```
***更新信息需要返回如下格式的`json`内容。***  
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
### 1、`JiuLing.AutoUpgrade`
自动更新的核心程序，用于完成整个更新的过程。

### 2、`JiuLing.AutoUpgrade.Shell`
这是一个很简单的壳程序。该程序将核心程序作为**资源文件**引入，调用自动更新时，释放并启动主更新程序。  

这样做有以下两个好处：
* `Shell`程序打包后可发布`Nuget`，便于版本管理。  
* 自动更新主程序的版本可实现自动升级（主程序是作为资源文件打包，因此只要替换资源文件并重新发布`Shell`程序即可）。  

### 3、`JiuLing.AutoUpgrade.Test`
自动更新的测试程序。

## :five:.License
MIT License