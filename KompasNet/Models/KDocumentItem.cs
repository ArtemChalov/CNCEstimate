
namespace KompasNet.Models
{
    public class KDocumentItem
    {
        public KDocumentItem(string name, bool active)
        {
            Name = name;
            Active = active;
        }

        public string Name { get; set; }
        public bool Active { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is KDocumentItem other)
            {
                return this.Name == other.Name;
            }
            return false;
        }
    }
}
