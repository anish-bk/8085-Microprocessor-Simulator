using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim
{
    internal class DataTransfer
    {
        private Registers register;
        private new Dictionary<string, string> codeHistory { get; set; }
        public DataTransfer(Dictionary<string, string> codeHistory, Registers register)
        {
            this.codeHistory = codeHistory;
            this.register = register;
        }
        public void movRToA(string parameter)
        {
            switch (parameter)
            {
                case "A":
                    register.RegA = register.RegA;
                    return;
                case "B":
                    register.RegA = register.RegB;
                    return;
                case "C":
                    register.RegA = register.RegC;
                    return;
                case "D":
                    register.RegA = register.RegD;
                    break;
                case "E":
                    register.RegA = register.RegE;
                    return;
                case "H":
                    register.RegA = register.RegH;
                    return;
                case "L":
                    register.RegA = register.RegL;
                    return;
                case "M":
                    register.RegA = register.RegM;
                    return;
            }
        }
        public void movRToB(string parameter)
        {
            switch (parameter)
            {
                case "A":
                    register.RegB = register.RegA;
                    return;
                case "B":
                    register.RegB = register.RegB;
                    return;
                case "C":
                    register.RegB = register.RegC;
                    return;
                case "D":
                    register.RegB = register.RegD;
                    return;
                case "E":
                    register.RegB = register.RegE;
                    return;
                case "H":
                    register.RegB = register.RegH;
                    return;
                case "L":
                    register.RegB = register.RegL;
                    return;
                case "M":
                    register.RegB = register.RegM;
                    return;
            }
        }
        public void movRToC(string parameter)
        {
            switch (parameter)
            {
                case "A":
                    register.RegC = register.RegA;
                    return;
                case "B":
                    register.RegC = register.RegB;
                    return;
                case "C":
                    register.RegC = register.RegC;
                    return;
                case "D":
                    register.RegC = register.RegD;
                    return;
                case "E":
                    register.RegC = register.RegE;
                    return;
                case "H":
                    register.RegC = register.RegH;
                    return;
                case "L":
                    register.RegC = register.RegL;
                    return;
                case "M":
                    register.RegC = register.RegM;
                    return;
            }
        }
        public void movRToD(string parameter)
        {
            switch (parameter)
            {
                case "A":
                    register.RegD = register.RegA;
                    return;
                case "B":
                    register.RegD = register.RegB;
                    return;
                case "C":
                    register.RegD = register.RegC;
                    return;
                case "D":
                    register.RegD = register.RegD;
                    return;
                case "E":
                    register.RegD = register.RegE;
                    return;
                case "H":
                    register.RegD = register.RegH;
                    return;
                case "L":
                    register.RegD = register.RegL;
                    return;
                case "M":
                    register.RegD = register.RegM;
                    return;
            }
        }
        public void movRToE(string parameter)
        {
            switch (parameter)
            {
                case "A":
                    register.RegE = register.RegA;
                    return;
                case "B":
                    register.RegE = register.RegB;
                    return;
                case "C":
                    register.RegE = register.RegC;
                    return;
                case "D":
                    register.RegE = register.RegD;
                    return;
                case "E":
                    register.RegE = register.RegE;
                    return;
                case "H":
                    register.RegE = register.RegH;
                    return;
                case "L":
                    register.RegE = register.RegL;
                    return;
                case "M":
                    register.RegE = register.RegM;
                    return;
            }
        }
        public void movRToH(string parameter)
        {
            switch (parameter)
            {
                case "A":
                    register.RegH = register.RegA;
                    return;
                case "B":
                    register.RegH = register.RegB;
                    return;
                case "C":
                    register.RegH = register.RegC;
                    return;
                case "D":
                    register.RegH = register.RegD;
                    return;
                case "E":
                    register.RegH = register.RegE;
                    return;
                case "H":
                    register.RegH = register.RegH;
                    return;
                case "L":
                    register.RegH = register.RegL;
                    return;
                case "M":
                    register.RegH = register.RegM;
                    return;
            }
        }
        public void movRToL(string parameter)
        {
            switch (parameter)
            {
                case "A":
                    register.RegL = register.RegA;
                    return;
                case "B":
                    register.RegL = register.RegB;
                    return;
                case "C":
                    register.RegL = register.RegC;
                    return;
                case "D":
                    register.RegL = register.RegD;
                    return;
                case "E":
                    register.RegL = register.RegE;
                    return;
                case "H":
                    register.RegL = register.RegH;
                    return;
                case "L":
                    register.RegL = register.RegL;
                    return;
                case "M":
                    register.RegL = register.RegM;
                    return;
            }
        }
        public void movRToM(string parameter)
        {
            switch (parameter)
            {
                case "A":
                    register.RegM = register.RegA;
                    return;
                case "B":
                    register.RegM = register.RegB;
                    return;
                case "C":
                    register.RegM = register.RegC;
                    return;
                case "D":
                    register.RegM = register.RegD;
                    return;
                case "E":
                    register.RegM = register.RegE;
                    return;
                case "H":
                    register.RegM = register.RegH;
                    return;
                case "L":
                    register.RegM = register.RegL;
                    return;
                case "M":
                    register.RegM = register.RegM;
                    return;
            }
        }
        public void moveImmediate(string parameter1, string value)
        {
            Console.WriteLine("moveImmediate Called");
            switch (parameter1)
            {
                case "A":
                    register.RegA = Convert.ToInt32(value, 16);
                    return;
                case "B":
                    register.RegB = Convert.ToInt32(value, 16);
                    return;
                case "C":
                    register.RegC = Convert.ToInt32(value, 16);
                    return;
                case "D":
                    register.RegD = Convert.ToInt32(value, 16);
                    return;
                case "E":
                    register.RegE = Convert.ToInt32(value, 16);
                    return;
                case "H":
                    register.RegH = Convert.ToInt32(value, 16);
                    return;
                case "L":
                    register.RegL = Convert.ToInt32(value, 16);
                    return;
                case "M":
                    register.RegM = Convert.ToInt32(value, 16);
                    return;
            }
        }
        public void load16BitDataToRegisters(string parameter1, string[] parameters)
        {
            Console.WriteLine("load16BitDataToRegisters Called");
            switch (parameter1)
            {
                case "B":
                    register.RegB = Convert.ToInt32(parameters[1], 16);
                    register.RegC = Convert.ToInt32(parameters[0], 16);
                    return;
                case "D":
                    register.RegD = Convert.ToInt32(parameters[1], 16);
                    register.RegE = Convert.ToInt32(parameters[0], 16);
                    return;
                case "H":
                    register.RegH = Convert.ToInt32(parameters[1], 16);
                    register.RegL = Convert.ToInt32(parameters[0], 16);
                    return;
                case "SP":
                    //register.RegB = Convert.ToInt32(this.codeHistory[parameter1], 16);
                    //register.RegC = Convert.ToInt32(this.codeHistory[parameter1], 16);
                    return;
            }
        }
        public int LoadToRegA(string parameter, string[] parameters)
        {
            Console.WriteLine("LoadToRegA Called");
            string temp1, temp2;
            switch (parameter)
            {
                case "B":
                    temp1 = Convert.ToString(register.RegB, 16);
                    temp2 = Convert.ToString(register.RegC, 16);
                    register.RegA = Convert.ToInt32(codeHistory[temp1 + temp2], 16);
                    return 1;
                case "D":
                    temp1 = Convert.ToString(register.RegD, 16);
                    temp2 = Convert.ToString(register.RegE, 16);
                    register.RegA = Convert.ToInt32(codeHistory[temp1 + temp2], 16);
                    return 1;
                case "I":
                    register.RegA = Convert.ToInt32(codeHistory[parameters[1] + parameters[0]], 16);
                    return 3;
                default:
                    return 1;
            }
        }
        public int StoreFromRegA(string parameter, string[] parameters)
        {
            Console.WriteLine("Store from accumulator Called");
            string? temp, temp1, temp2;
            switch (parameter)
            {
                case "B":
                    temp1 = Convert.ToString(register.RegB, 16);
                    temp2 = Convert.ToString(register.RegC, 16);
                    temp = temp1 + temp2;
                    if (codeHistory.ContainsKey(temp))
                        codeHistory[temp] = Convert.ToString(register.RegA, 16);
                    else
                        codeHistory.Add(temp, Convert.ToString(register.RegA, 16));
                    return 1;
                case "D":
                    temp1 = Convert.ToString(register.RegD, 16);
                    temp2 = Convert.ToString(register.RegE, 16);
                    temp = temp1 + temp2;
                    if (codeHistory.ContainsKey(temp))
                        codeHistory[temp] = Convert.ToString(register.RegA, 16);
                    else
                        codeHistory.Add(temp, Convert.ToString(register.RegA, 16));
                    return 1;
                case "I":
                    temp = parameters[1] + parameters[0];
                    if (codeHistory.ContainsKey(temp))
                        codeHistory[temp] = Convert.ToString(register.RegA, 16);
                    else
                        codeHistory.Add(temp, Convert.ToString(register.RegA, 16));
                    return 3;
                default:
                    return 1;
            }
        }
    }
}
