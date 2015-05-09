using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjection.Bi
{
    public interface IProduktBi
    {
        string LoadProdukt(string id);

        void SaveProdukt(string id);
    }

    public class ProduktBi : IProduktBi
    {
        public string LoadProdukt(string id)
        {
            return id;
        }

        public void SaveProdukt(string id) {}
    }
}
