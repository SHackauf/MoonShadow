using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Model;

namespace Unity.Bi
{
    public class YourDatabase : IDatabase
    {
        string _dbName, _tablename;
        public YourDatabase(string aDbName, string aTablename)
        {
            this._dbName = aDbName;
            this._tablename = aTablename;
        }

        public Kunde LoadKunde(int aId)
        {
            return new Kunde() { Id = aId, Name = "YourDatabase" };
        }
    }
}
