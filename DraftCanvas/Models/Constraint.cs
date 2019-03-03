using System.Collections.Generic;

namespace DraftCanvas.Models
{
    public class Constraint
    {
        public Constraint(string group, List<int> members, string relation)
        {
            Group = group;
            Members = members;
            Relation = relation;
        }

        public string Group { get; set; }
        public List<int> Members {get; set;}
        public string Relation { get; set; }
    }
}
