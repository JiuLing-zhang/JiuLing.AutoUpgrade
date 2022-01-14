# AutoUpgrade
一个.net 6写的自动更新组件

# 使用  
自动更新检查接口需要返回如下格式的`json`内容
```json
{
    "Version":"最新的版本号（必须返回）",
    "MinVersion":"程序运行的最低版本号，低于此版本将无法运行",
    "DownloadUrl":"程序的下载路径（必须返回）",
    "Log":"更新日志",
    "CreateTime":"时间"
}
```