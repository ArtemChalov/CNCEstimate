
namespace DraftCanvas.Models
{
    public class Constraint
    {
        private readonly int _issuer;
        private readonly int _sub;
        private readonly string _relationType;

        public Constraint(int issuerIndex, int subIndex, string relationType)
        {
            _issuer = issuerIndex;
            _sub = subIndex;
            _relationType = relationType;
        }

        public int IssuerIndex => _issuer;
        public int SubIndex => _sub;
        public string RelationType => _relationType;
    }
}
