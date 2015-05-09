using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjection.Bi
{
    public interface IKundeBi
    {
        int LoadKunde(int n);
        void SaveKunde(int n);
    }

    public class KundeBi : IKundeBi
    {
        public int LoadKunde(int n)
        {
            return n;
        }

        public void SaveKunde(int n) {}
    }
}
