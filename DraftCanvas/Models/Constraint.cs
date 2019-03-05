
namespace DraftCanvas.Models
{
    public class Constraint
    {
        private readonly int _issuer;
        private int _sub;
        private readonly string _relationType;

        public Constraint(int issuerId, string relationType)
        {
            _issuer = issuerId;
            _relationType = relationType;
        }

        public int IssuerID => _issuer;
        public int SubID => _sub;
        public string RelationType => _relationType;

        public void SetSub(int subId)
        {
            _sub = subId;
        }
    }
}
