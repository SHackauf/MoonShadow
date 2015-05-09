
namespace UnityInterception.Model
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("[{0} [Id: {1}][Name {2}]]", this.GetType().Name, Id, Name);
        }
    }
}
