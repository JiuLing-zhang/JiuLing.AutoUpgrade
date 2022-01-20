namespace AutoUpgrade.ExtensionMethods
{
    /// <summary>
    /// 字符串类型的扩展方法
    /// </summary>
    public static class StringExtension
    {
        public static bool IsEmpty(this string input) => string.IsNullOrEmpty(input);
        public static bool IsNotEmpty(this string input) => !string.IsNullOrEmpty(input);
    }
}
