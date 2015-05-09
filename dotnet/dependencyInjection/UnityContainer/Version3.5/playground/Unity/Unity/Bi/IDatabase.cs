using Unity.Model;

namespace Unity.Bi
{
    public interface IDatabase
    {
        Kunde LoadKunde(int aId);
    }
}
