using System.Collections.Generic;

namespace KompasNet.Dictionaries
{
    public class HelpDict
    {
        public Dictionary<double, string> ScaleDictionary;
        public HelpDict()
        {
            CreateScales();
        }

        private void CreateScales()
        {
            ScaleDictionary = new Dictionary<double, string>()
            {
                { 0.01, "1:100" },
                { 0.02, "1:50" },  
                { 0.025, "1:40" },  
                { 0.04, "1:25" },  
                { 0.05, "1:20" },  
                { 0.1, "1:10" },  
                { 0.2, "1:5" },   
                { 0.25, "1:4" },   
                { 0.5, "1:2" }, 
                { 1, "1:1" },   
                { 2, "2:1" },   
                { 4, "4:1" },   
                { 5, "5:1" },   
                { 10, "10:1" }, 
                { 20, "20:1" }, 
                { 40, "40:1" }, 
                { 50, "50:1" }, 
                { 100, "100:1" }
            };
        }
    }
}
