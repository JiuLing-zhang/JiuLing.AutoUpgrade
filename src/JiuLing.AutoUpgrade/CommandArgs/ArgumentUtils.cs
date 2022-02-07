using System.Collections;
using System.Text.RegularExpressions;

namespace JiuLing.AutoUpgrade.CommandArgs
{
    internal class ArgumentUtils
    {
        private static string _input = null!;
        private static readonly Hashtable Result = new Hashtable();
        public static void Initialize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("启动参数不能为空");
            }
            _input = input;
            BuildArgs();
        }

        private static void BuildArgs()
        {
            string pattern = @"(?<=(\s|^))-.*?(?=(?<=(\s|^))-|$)";
            MatchCollection mc = Regex.Matches(_input, pattern);
            if (mc.Count == 0)
            {
                throw new ArgumentException("未匹配到任何启动参数");
            }

            foreach (Match m in mc)
            {
                string argPart = m.Value.Trim();
                var argList = new List<string>(argPart.Split(' '));

                string commandKey = argList[0].Trim();
                argList.RemoveAt(0);
                if (Result.ContainsKey(commandKey))
                {
                    throw new Exception("参数重复");
                }
                Result.Add(commandKey, argList);
            }
        }

        public static bool HasCommand(string key)
        {
            return Result.ContainsKey(key);
        }

        public static List<string>? GetCommandValue(string key)
        {
            if (!Result.ContainsKey(key))
            {
                return default(List<string>);
            }
            return Result[key] as List<string>;
        }

        public static bool TryGetCommandValue(string key, out List<string> commandValue)
        {

            if (!Result.ContainsKey(key))
            {
                commandValue = null!;
                return false;
            }

            if (Result[key] is not List<string> value)
            {
                commandValue = null!;
                return false;
            }
            commandValue = value;
            return true;
        }
    }
}
