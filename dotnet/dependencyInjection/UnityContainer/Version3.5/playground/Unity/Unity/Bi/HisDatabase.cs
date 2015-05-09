using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Model;

namespace Unity.Bi
{
    public class HisDatabase : IDatabase
    {
        public Kunde LoadKunde(int aId)
        {
            return new Kunde() { Id = aId, Name = "HisDatabase" };
        }

        public string Name { get; set; }
    }
}
