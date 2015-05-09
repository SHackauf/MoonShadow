using PolicyInjection.Interception;

namespace PolicyInjection.Bi.Admin
{
    public interface IAttributBi
    {
        int LoadConfig();
        void SaveConfig();
    }

    public class AttributBi : IAttributBi
    {
        [AttributeHandler(1)]
        public int LoadConfig()
        {
            return 1;
        }

        [AttributeHandler(1)]
        public void SaveConfig() { }
    }
}
