using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Shell
{
    /// <summary>
    /// 自动更新组件工厂
    /// </summary>
    public class AutoUpgradeFactory
    {
        /// <summary>
        /// 创建组件
        /// </summary>
        /// <returns></returns>
        public static App Create()
        {
            return new App();
        }
    }
}
