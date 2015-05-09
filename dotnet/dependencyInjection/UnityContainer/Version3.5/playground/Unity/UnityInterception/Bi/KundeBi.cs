using UnityInterception.Model;

namespace UnityInterception.Bi
{
    public interface IKundeBi
    {
        Kunde Load(int id);
        void Save(Kunde kunde);
        void Delete(Kunde kunde);
        bool Check(Kunde kunde, out string detail);
    }

    public class KundeBi : IKundeBi
    {
        public Kunde Load(int id)
        {
            return new Kunde(){Id = id, Name = "Dieter"};
        }

        public void Save(Kunde kunde)
        {
            string detail;
            Check(kunde, out detail);
        }

        virtual public void Delete(Kunde kunde)
        {
            string detail;
            Check(kunde, out detail);
        }

        virtual public bool Check(Kunde kunde, out string detail)
        {
            detail = "bla";
            return true;
        }
    }
}
