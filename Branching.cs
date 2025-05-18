using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim
{
    internal class Branching
    {
        private Registers register = new Registers();
        private Flags flag = new Flags();
        int programCounter;
        Dictionary<string, string> codeHistory = new Dictionary<string, string>();
        CStack stack = new CStack();
        public Branching(Registers register, Flags flag, int programCounter, Dictionary<string, string> codeHistory, CStack stack)
        {
            this.register = register;
            this.flag = flag;
            this.programCounter = programCounter;
            this.codeHistory = codeHistory;
            this.stack = stack;
        }
        public int JUMP(string parameter, string[] parameters, int programCounter)
        {
            Console.WriteLine("JUMP called");
            string temp = parameters[1] + parameters[0];
            bool condition;
            Console.WriteLine(parameter);
            switch (parameter)
            {
                case "JMP":
                    return Convert.ToInt32(temp, 16);
                case "JNZ":
                    condition = !flag.FlagZ;
                    break;
                case "JZ":
                    condition = flag.FlagZ;
                    break;
                case "JNC":
                    condition = !flag.FlagCY;
                    break;
                case "JC":
                    condition = flag.FlagCY;
                    break;
                case "JPO":
                    condition = !flag.FlagP;
                    break;
                case "JPE":
                    condition = flag.FlagP;
                    break;
                case "JP":
                    condition = !flag.FlagS;
                    break;
                case "JM":
                    condition = flag.FlagS;
                    break;
                case "PCHL":
                    string high = Convert.ToString(register.RegH, 16).PadLeft(2, '0');
                    string low = Convert.ToString(register.RegL, 16).PadLeft(2, '0');
                    string pc = high + low;
                    return Convert.ToInt32(pc, 16);
                default:
                    return programCounter + 3;
            }
            return condition ? Convert.ToInt32(temp, 16) : (programCounter + 3);
        }
        public int CALL(string parameter, string[] parameters, int programCounter)
        {
            bool condition;
            switch (parameter)
            {
                case "CALL":
                    return call(parameters, programCounter);
                case "CNZ":
                    condition = !flag.FlagZ;
                    break;
                case "CZ":
                    condition = flag.FlagZ;
                    break;
                case "CNC":
                    condition = !flag.FlagCY;
                    break;
                case "CC":
                    condition = flag.FlagCY;
                    break;
                case "CPO":
                    condition = !flag.FlagP;
                    break;
                case "CPE":
                    condition = flag.FlagP;
                    break;
                case "CP":
                    condition = !flag.FlagS;
                    break;
                case "CM":
                    condition = flag.FlagS;
                    break;
                default:
                    return programCounter + 1;
            }
            return condition ? call(parameters, programCounter) : programCounter + 1;
        }
        public int RET(string parameter)
        {
            bool condition;
            switch (parameter)
            {
                case "RET":
                    return ret();
                case "RNZ":
                    condition = !flag.FlagZ;
                    break;
                case "RZ":
                    condition = flag.FlagZ;
                    break;
                case "RNC":
                    condition = !flag.FlagCY;
                    break;
                case "RC":
                    condition = flag.FlagCY;
                    break;
                case "RPO":
                    condition = !flag.FlagP;
                    break;
                case "RPE":
                    condition = flag.FlagP;
                    break;
                case "RP":
                    condition = !flag.FlagS;
                    break;
                case "RM":
                    condition = flag.FlagS;
                    break;
                default:
                    return programCounter + 1;
            }
            return condition ? ret() : programCounter + 1;
        }
        public int call(string[] parameters, int programCounter)
        {
            Console.WriteLine("CALL Called");
            int pc;
            parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
            parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
            string temp = parameters[1] + parameters[0];
            string temp1 = Convert.ToString(programCounter + 3, 16);
            //stack.Push(temp1);
            string temp2 = temp1.Substring(0, 2);
            string temp3 = temp1.Substring(2, 2);
            stack.Push(temp2);
            stack.Push(temp3);
            pc = Convert.ToInt32(temp, 16);
            return pc;
        }
        public int ret()
        {
            Console.WriteLine("RET Called");
            string temp1 = stack.Pop();
            string temp2 = stack.Pop();
            //string temp = stack.Pop();
            string temp = temp2 + temp1;
            programCounter = Convert.ToInt32(temp, 16);
            return programCounter;
        }
    }
}
