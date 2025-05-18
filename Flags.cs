using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim
{
    internal class Flags
    {
        public Flags()
        {
            FlagS = FlagZ = FlagAC = FlagP = FlagCY = false;
        }
        public bool FlagS { get; set; }
        public bool FlagZ { get; set; }
        public bool FlagAC { get; set; }
        public bool FlagP { get; set; }
        public bool FlagCY { get; set; }
        public void setFlagS() { FlagS = true; }
        public void setFlagZ() { FlagZ = true; }
        public void setFlagAC() { FlagAC = true; }
        public void setFlagP() { FlagP = true; }
        public void setFlagCY() { FlagCY = true; }
        public void resetFlagS() { FlagS = false; }
        public void resetFlagZ() { FlagZ = false; }
        public void resetFlagAC() { FlagAC = false; }
        public void resetFlagP() { FlagP = false; }
        public void resetFlagCY() { FlagCY = false; }
    }
}
