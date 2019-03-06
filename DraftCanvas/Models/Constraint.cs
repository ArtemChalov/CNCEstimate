
namespace DraftCanvas.Models
{
    public class Constraint
    {
        private readonly int _issuer;
        private int _sub;
        private string _issuerName;
        private string _SubName;
        private readonly string _relationType;

        public Constraint(int issuerId, string relationType)
        {
            _issuer = issuerId;
            _relationType = relationType;
        }

        public Constraint(int issuerId, string issuerName, string relationType)
        {
            _issuer = issuerId;
            _issuerName = issuerName;
            _relationType = relationType;
        }

        public string IssuerName => _issuerName;
        public int IssuerID => _issuer;
        public string SubName => _SubName;
        public int SubID => _sub;
        public string RelationType => _relationType;

        public void SetSub(int subId)
        {
            _sub = subId;
        }

        public void SetSub(int subId, string subName)
        {
            _sub = subId;
            _SubName = subName;
        }
    }
}
