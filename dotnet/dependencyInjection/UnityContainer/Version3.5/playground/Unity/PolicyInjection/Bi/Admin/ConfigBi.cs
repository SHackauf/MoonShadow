using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjection.Bi.Admin
{
    public interface IConfigBi
    {
        int LoadConfig();
        void SaveConfig();
    }

    public class ConfigBi : IConfigBi
    {
        public int LoadConfig()
        {
            return 1;
        }

        public void SaveConfig() {}
    }
}
