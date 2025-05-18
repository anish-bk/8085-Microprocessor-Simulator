using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim
{
    internal class HexCodes
    {
        public Dictionary<string, string> codeHistory = new Dictionary<string, string>();
        public void showCodes()
        {
            foreach (var kvp in codeHistory)
                Console.WriteLine(kvp.Key.PadLeft(4, '0') + ":\t" + Convert.ToString(kvp.Value).PadLeft(2, '0'));
        }
        public void takeOpCodes(string s1)
        {
            codeHistory.Add("8000", s1.Substring(0,2));
            codeHistory.Add("8001", s1.Substring(2, 4));
            codeHistory.Add("8002", s1.Substring(4, 6));
            codeHistory.Add("8003", s1.Substring(6, 8));
            codeHistory.Add("8004", s1.Substring(8, 10));
            codeHistory.Add("8005", s1.Substring(10, 12));
            codeHistory.Add("8006", s1.Substring(12, 14));
            //codeHistory.Add("8007", s1.Substring(14, 16));
            //codeHistory.Add("8008", s1.Substring(16, 18));
            //codeHistory.Add("8009", s1.Substring(18, 20));
            //codeHistory.Add("800a", s1.Substring(20, 22));
            //codeHistory.Add("800b", s1.Substring(22, 24));
            //codeHistory.Add("800c", s1.Substring(24, 26));
            //codeHistory.Add("800d", s1.Substring(26, 28));
            //codeHistory.Add("800e", s1.Substring(28, 30));
            //codeHistory.Add("800f", s1.Substring());
            //codeHistory.Add("8010", s1.Substring());
            //codeHistory.Add("8011", s1.Substring());
            //codeHistory.Add("8012", s1.Substring());
            //codeHistory.Add("8013", s1.Substring());
            //codeHistory.Add("8014", s1.Substring());
            //codeHistory.Add("8015", "90");
            //codeHistory.Add("8016", "80");
            //codeHistory.Add("8017", "ef");
            //codeHistory.Add("8080", "00");
            //codeHistory.Add("8081", "00");
            //codeHistory.Add("8090", "00");
            //codeHistory.Add("8091", "00");
            //codeHistory.Add("8011", "2a");
        }
    }
}
