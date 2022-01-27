using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    internal class StartArgumentContext
    {
        private readonly StartArgumentStrategy _strategy;
        public StartArgumentContext(StartArgumentStrategy strategy)
        {
            _strategy = strategy;
        }

        public string GetStartArguments(string mainProcessName, ConnectionTypeEnum connectionType)
        {
            return _strategy.Build(mainProcessName, connectionType);
        }
    }
}
