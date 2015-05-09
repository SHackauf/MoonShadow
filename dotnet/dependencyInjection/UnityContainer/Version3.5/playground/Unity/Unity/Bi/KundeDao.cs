namespace Unity.Bi
{
    public class KundeDao
    {
        private IDatabase _database;
        public KundeDao(IDatabase aDatabase)
        {
            this._database = aDatabase;
        }
    }
}
