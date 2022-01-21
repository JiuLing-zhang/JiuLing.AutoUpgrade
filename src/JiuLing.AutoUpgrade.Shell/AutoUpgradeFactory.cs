using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Shell
{
    public class AutoUpgradeFactory
    {
        public static App Create()
        {
            return new App();
        }
    }
}
