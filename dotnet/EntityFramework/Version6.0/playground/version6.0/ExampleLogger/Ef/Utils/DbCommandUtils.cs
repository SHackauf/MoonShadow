using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLogger.Ef.Utils
{
    static class DbCommandUtils
    {
        public static string OneLineText(DbCommand command)
        {
            return command.CommandText.Replace(Environment.NewLine + "    ", "").Replace(Environment.NewLine, "");
        }
    }
}
