using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim
{
    internal class InstructionSet
    {
        public Dictionary<string, string> movASet = new Dictionary<string, string>
            {
                {"7F", "A"}, {"7f", "A" }, {"78" , "B"}, {"79" , "C"}, {"7A", "D" }, {"7a" , "D"}, {"7B", "E"},
                {"7b", "E" }, {"7C" , "H"}, {"7c", "H"}, {"7D" , "L"}, {"7d", "L" }, {"7E" , "M"}, {"7e", "M"}
            };
        public Dictionary<string, string> movBSet = new Dictionary<string, string>
            {
                {"47", "A"}, {"40" , "B"}, {"41" , "C"}, {"42" , "D"}, {"43" , "E"}, {"44" , "H"}, {"45" , "L"}, {"46" , "M"}
            };
        public Dictionary<string, string> movCSet = new Dictionary<string, string>
            {
                {"4F", "A"}, {"4f", "A" }, {"48" , "B"}, {"49" , "C"}, {"4A", "D" }, {"4a" , "D"}, {"4B", "E"},
                {"4b", "E" }, {"4C" , "H"}, {"4c", "H"}, {"4D" , "L"}, {"4d", "L" }, {"4E" , "M"}, {"4e", "M"}
            };
        public Dictionary<string, string> movDSet = new Dictionary<string, string>
            {
                {"57", "A"}, {"50" , "B"}, {"51" , "C"}, {"52" , "D"}, {"53" , "E"}, {"54" , "H"}, {"55" , "L"}, {"56" , "M"}
            };
        public Dictionary<string, string> movESet = new Dictionary<string, string>
            {
                {"5F", "A"}, {"5f", "A" }, {"58" , "B"}, {"59" , "C"}, {"5A", "D" }, {"5a" , "D"}, {"5B", "E"},
                {"5b", "E" }, {"5C" , "H"}, {"5c", "H"}, {"5D" , "L"}, {"5d", "L" }, {"5E" , "M"}, {"5e", "M"}
            };
        public Dictionary<string, string> movHSet = new Dictionary<string, string>
            {
                {"67", "A"}, {"60" , "B"}, {"61" , "C"}, {"62" , "D"}, {"63" , "E"}, {"64" , "H"}, {"65" , "L"}, {"66" , "M"}
            };
        public Dictionary<string, string> movLSet = new Dictionary<string, string>
            {
                {"6F", "A"}, {"6f", "A" }, {"68" , "B"}, {"69" , "C"}, {"6A", "D" }, {"6a" , "D"}, {"6B", "E"},
                {"6b", "E" }, {"6C" , "H"}, {"6c", "H"}, {"6D" , "L"}, {"6d", "L" }, {"6E" , "M"}, {"6e", "M"}
            };
        public Dictionary<string, string> movMSet = new Dictionary<string, string>
            {
                {"77", "A"}, {"70" , "B"}, {"71" , "C"}, {"72" , "D"}, {"73" , "E"}, {"74" , "H"}, {"75" , "L"}, {"76" , "M"}
            };
        public Dictionary<string, string> mviSet = new Dictionary<string, string>
            {
                {"3E", "A"}, {"3e", "A" }, {"06" , "B"}, {"0E" , "C"}, {"0e", "C" }, {"16" , "D"},
                {"1E", "E"}, {"1e", "E" }, {"26" , "H"}, {"2E" , "L"}, {"2e", "L" }, {"36" , "M"}
            };
        public Dictionary<string, string> lxiSet = new Dictionary<string, string>
            {
                {"01", "B"}, {"11", "D"}, {"21", "H"}, {"31", "SP"}
            };
        public Dictionary<string, string> ldaSet = new Dictionary<string, string>
        {
            {"0A", "B"}, {"0a", "B"}, {"1A", "D"}, {"1a", "D"}, {"3A", "I"}, {"3a", "I"}
        };
        public Dictionary<string, string> staSet = new Dictionary<string, string>
        {
            {"02", "B"}, {"12", "D"}, {"32", "I"}
        };
        public Dictionary<string, string> addSet = new Dictionary<string, string>
            {
                {"87", "A"}, {"80" , "B"}, {"81" , "C"}, {"82" , "D"}, {"83" , "E"}, {"84" , "H"},
                {"85" , "L"}, {"86" , "M"}, {"C6", "I"}, {"c6", "I"}
            };
        public Dictionary<string, string> adcSet = new Dictionary<string, string>
            {
                {"8F", "A"}, {"8f", "A" }, {"88" , "B"}, {"89" , "C"}, {"8A" , "D"}, {"8a", "D" }, {"8B", "E"}, {"8b", "E"},
                {"8C" , "H"}, {"8c", "H" }, {"8D" , "L"}, {"8d", "L" }, {"8E" , "M"}, {"8e", "M"}, {"CE", "I"}, {"ce", "I"}
            };
        public Dictionary<string, string> subSet = new Dictionary<string, string>
            {
                {"97", "A"}, {"90" , "B"}, {"91" , "C"}, {"92" , "D"}, {"93" , "E"}, {"94" , "H"},
                {"95", "L"}, {"96" , "M"}, {"D6", "I"}, {"d6", "I"}
            };
        public Dictionary<string, string> sbbSet = new Dictionary<string, string>
            {
                {"9F", "A"}, {"9f", "A" }, {"98" , "B"}, {"99" , "C"}, {"9A" , "D"}, {"9a", "D"}, {"9B", "E"}, {"9b", "E"},
                {"9C", "H"}, {"9c", "H" }, {"9D" , "L"}, {"9d", "L" }, {"9E" , "M"}, {"9e", "M"}, {"DE", "I"}, {"de", "I"}
            };
        public Dictionary<string, string> anaSet = new Dictionary<string, string>
            {
                {"A7", "A"}, {"A0" , "B"}, {"A1" , "C"}, {"A2" , "D"}, {"A3" , "E"}, {"A4" , "H"}, {"A5" , "L"}, {"A6" , "M"},
                {"a7", "A"}, {"a0" , "B"}, {"a1" , "C"}, {"a2" , "D"}, {"a3" , "E"}, {"a4" , "H"}, {"a5" , "L"}, {"a6" , "M"},
                {"E6", "I"}, {"e6", "I"}
            };
        public Dictionary<string, string> xraSet = new Dictionary<string, string>
            {
                {"AF", "A"}, {"A8" , "B"}, {"A9" , "C"}, {"AA" , "D"}, {"AB" , "E"}, {"AC" , "H"}, {"AD" , "L"}, {"AE" , "M"},
                {"af", "A"}, {"a8" , "B"}, {"a9" , "C"}, {"aa" , "D"}, {"ab" , "E"}, {"ac" , "H"}, {"ad" , "L"}, {"ae" , "M"}
            };
        public Dictionary<string, string> oraSet = new Dictionary<string, string>
            {
                {"B7", "A"}, {"B0" , "B"}, {"B1" , "C"}, {"B2" , "D"}, {"B3" , "E"}, {"B4" , "H"}, {"B5" , "L"}, {"B6" , "M"},
                {"b7", "A"}, {"b0" , "B"}, {"b1" , "C"}, {"b2" , "D"}, {"b3" , "E"}, {"b4" , "H"}, {"b5" , "L"}, {"b6" , "M"},
                {"F6", "I"}, {"f6", "I"}
            };
        public Dictionary<string, string> cmpSet = new Dictionary<string, string>
            {
                {"BF", "A"}, {"B8" , "B"}, {"B9" , "C"}, {"BA" , "D"}, {"BB" , "E"}, {"BC" , "H"}, {"BD" , "L"}, {"BE" , "M"},
                {"bf", "A"}, {"b8" , "B"}, {"b9" , "C"}, {"ba" , "D"}, {"bb" , "E"}, {"bc" , "H"}, {"bd" , "L"}, {"be" , "M"}
            };
        public Dictionary<string, string> inrSet = new Dictionary<string, string>
            {
                {"3C", "A"}, {"3c", "A"}, {"04" , "B"}, {"0C" , "C"}, {"0c", "C"}, {"14" , "D"},
                {"1C", "E"}, {"1c", "E"}, {"24" , "H"}, {"2C" , "L"}, {"2c", "L"}, {"34" , "M"}
            };
        public Dictionary<string, string> dcrSet = new Dictionary<string, string>
            {
                {"3D", "A"}, {"3d", "A"}, {"05" , "B"}, {"0D" , "C"}, {"0d", "C"}, {"15" , "D"},
                {"1D", "E"}, {"1d", "E"}, {"25" , "H"}, {"2D" , "L"}, {"2d", "L"}, {"35" , "M"}
            };
        public Dictionary<string, string> inxSet = new Dictionary<string, string>
            {
                {"03", "B"}, {"13", "D"}, {"23", "H"}, {"33", "SP"}
            };
        public Dictionary<string, string> dcxSet = new Dictionary<string, string>
            {
                {"0B", "B"}, {"1B", "D"}, {"2B", "H"}, {"3B", "SP"},
                {"0b", "B"}, {"1b", "D"}, {"2b", "H"}, {"3b", "SP"}
            };
        public Dictionary<string, string> jumpSet = new Dictionary<string, string>
        {
            {"C3", "JMP"}, {"C2", "JNZ"}, {"CA", "JZ"}, {"D2", "JNC"}, {"DA", "JC"},
            {"E2", "JPO"}, {"EA", "JPE"}, {"F2", "JP"}, {"FA", "JM"}, {"E9", "PCHL"},
            {"c3", "JMP"}, {"c2", "JNZ"}, {"ca", "JZ"}, {"d2", "JNC"}, {"da", "JC"},
            {"e2", "JPO"}, {"ea", "JPE"}, {"f2", "JP"}, {"fa", "JM"}, {"e9", "PCHL"}
        };
        public Dictionary<string, string> callSet = new Dictionary<string, string>
        {
            {"CD", "CALL"}, {"C4", "CNZ"}, {"CC", "CZ"}, {"D4", "CNC"}, {"DC", "CC"},
            {"E4", "CPO"}, {"EC", "CPE"}, {"F4", "CP"}, {"FC", "CM"}
        };
        public Dictionary<string, string> retSet = new Dictionary<string, string>
        {
            {"C9", "RET"}, {"C0", "RNZ"}, {"C8", "RZ"}, {"D0", "RNC"}, {"D8", "RC"},
            {"E0", "RPO"}, {"E8", "RPE"}, {"F0", "RP"}, {"F8", "RM"}
        };
        public Dictionary<string, string> rotSet = new Dictionary<string, string>
        {
            {"07", "RLC"}, {"0f", "RRC"}, {"0F", "RRC" }, {"17", "RAL"}, {"1f", "RAR"}, {"1F", "RAR"}
        };
    }
}
