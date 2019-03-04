
namespace DraftCanvas.Models
{
    public class Constraint
    {
        private readonly int _issuer;
        private readonly int _sub;
        private readonly string _relationType;

        public Constraint(int issuerId, string relationType)
        {
            _issuer = issuerId;
            _relationType = relationType;
        }

        public int IssuerID => _issuer;
        public int SubID { get; set; }
        public string RelationType => _relationType;
    }
}
