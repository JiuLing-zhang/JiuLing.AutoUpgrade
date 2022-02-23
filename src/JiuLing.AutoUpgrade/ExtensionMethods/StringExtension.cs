using System;

namespace JiuLing.AutoUpgrade.ExtensionMethods
{
    /// <summary>
    /// 字符串类型的扩展方法
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string input) => string.IsNullOrEmpty(input);
        /// <summary>
        /// 是否不为空
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string input) => !string.IsNullOrEmpty(input);
    }
}
