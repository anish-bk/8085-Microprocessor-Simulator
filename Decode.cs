using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Routing;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim
{
    internal class Decode
    {
        public Registers register;
        public Flags flag;
        public string? initAddress;
        public int programCounter;
        public CStack stack;
        public string? stackPointer;
        public InstructionSet iSet = new InstructionSet();
        public Dictionary<string, string> codeHistory = new Dictionary<string, string>();
        public Dictionary<string, string> registers = new Dictionary<string, string>();
        public Dictionary<string, string> flags = new Dictionary<string, string>();
        public DataTransfer dt;
        public ALU alu;
        public Branching br;
        public Rotate rt;
        public Decode(Dictionary<string, string> codeHistory)
        {
            this.codeHistory = codeHistory;
            initAddress = getInitAddress(codeHistory);
            programCounter = Convert.ToInt32(initAddress, 16);
            register = new Registers();
            flag = new Flags();
            stack = new CStack();
            stackPointer = "8f88";
            dt = new DataTransfer(codeHistory, register);
            alu = new ALU(register, flag);
            br = new Branching(register, flag, programCounter, codeHistory, stack);
            rt = new Rotate(register, flag);
            registers.Add("A", "00".PadLeft(2, '0'));
            registers.Add("B", "00".PadLeft(2, '0'));
            registers.Add("C", "00".PadLeft(2, '0'));
            registers.Add("D", "00".PadLeft(2, '0'));
            registers.Add("E", "00".PadLeft(2, '0'));
            registers.Add("H", "00".PadLeft(2, '0'));
            registers.Add("L", "00".PadLeft(2, '0'));
            registers.Add("M", "00".PadLeft(2, '0'));
            flags.Add("S", "0");
            flags.Add("Z", "0");
            flags.Add("AC", "0");
            flags.Add("P", "0");
            flags.Add("CY", "0");
        }
        public void operation()
        {
            string[] parameters = new string[2];
            programCounter = Convert.ToInt32(initAddress, 16);
            string parameter;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Program Counter: " + Convert.ToString(programCounter, 16));
                showRegandFlag();
                //updateRegisters();
                stack.Display();
                initAddress = Convert.ToString(programCounter, 16);
                parameter = codeHistory[initAddress];
                if (iSet.movASet.ContainsKey(parameter))
                {
                    dt.movRToA(iSet.movASet[parameter]);
                    programCounter++;
                }
                else if (iSet.movBSet.ContainsKey(parameter))
                {
                    dt.movRToB(iSet.movBSet[parameter]);
                    programCounter++;
                }
                else if (iSet.movCSet.ContainsKey(parameter))
                {
                    dt.movRToC(iSet.movCSet[parameter]);
                    programCounter++;
                }
                else if (iSet.movDSet.ContainsKey(parameter))
                {
                    dt.movRToD(iSet.movDSet[parameter]);
                    programCounter++;
                }
                else if (iSet.movESet.ContainsKey(parameter))
                {
                    dt.movRToE(iSet.movESet[parameter]);
                    programCounter++;
                }
                else if (iSet.movHSet.ContainsKey(parameter))
                {
                    dt.movRToH(iSet.movHSet[parameter]);
                    programCounter++;
                }
                else if (iSet.movLSet.ContainsKey(parameter))
                {
                    dt.movRToL(iSet.movLSet[parameter]);
                    programCounter++;
                }
                else if (iSet.movMSet.ContainsKey(parameter))
                {
                    dt.movRToM(iSet.movMSet[parameter]);
                    programCounter++;
                }
                else if (parameter == "EB" || parameter == "eb")
                {
                    // XCHG
                    Console.WriteLine("XCHG Called");
                    int regW, regZ;
                    regW = register.RegD;
                    regZ = register.RegE;
                    register.RegD = register.RegH;
                    register.RegE = register.RegL;
                    register.RegH = regW;
                    register.RegL = regZ;
                    programCounter += 1;
                }
                else if (iSet.mviSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    dt.moveImmediate(iSet.mviSet[parameter], parameters[0]);
                    programCounter += 2;
                }
                else if (iSet.lxiSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
                    dt.load16BitDataToRegisters(iSet.lxiSet[parameter], parameters);
                    programCounter += 3;
                }
                else if (iSet.ldaSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
                    int count = dt.LoadToRegA(iSet.ldaSet[parameter], parameters);
                    programCounter += count;
                }
                else if (parameter == "2A" || parameter == "2a")
                {
                    Console.WriteLine("LHLD Called");
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
                    string temp = parameters[1] + parameters[0];
                    register.RegL = Convert.ToInt32(codeHistory[temp], 16);
                    int temp1 = Convert.ToInt32(temp, 16);
                    temp1++;
                    register.RegH = Convert.ToInt32(codeHistory[Convert.ToString(temp1, 16)], 16);
                    programCounter += 3;
                }
                else if (iSet.staSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
                    int count = dt.StoreFromRegA(iSet.staSet[parameter], parameters);
                    programCounter += count;
                }
                else if (parameter == "22")
                {
                    Console.WriteLine("SHLD Called");
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
                    string temp = parameters[1] + parameters[0];
                    if (codeHistory.ContainsKey(temp))
                        codeHistory[temp] = Convert.ToString(register.RegL, 16);
                    else
                        codeHistory.Add(temp, Convert.ToString(register.RegL, 16));
                    int temp1 = Convert.ToInt32(temp, 16);
                    string temp2 = Convert.ToString(temp1 + 1, 16);
                    if (codeHistory.ContainsKey(temp2))
                        codeHistory[temp2] = Convert.ToString(register.RegH, 16);
                    else
                        codeHistory.Add(temp2, Convert.ToString(register.RegH, 16));
                    programCounter += 3;
                }
                else if (iSet.addSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    int count = alu.Addition(iSet.addSet[parameter], parameters[0]);
                    alu.checkParityAndZero(register.RegA);
                    programCounter += count;
                }
                else if (iSet.adcSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    int count = alu.AdditionWithCarry(iSet.adcSet[parameter], parameters[0]);
                    alu.checkParityAndZero(register.RegA);
                    programCounter += count;
                }
                else if (iSet.subSet.ContainsKey(parameter))
                {
                    alu.Subtraction(iSet.subSet[parameter]);
                    alu.checkParityAndZero(register.RegA);
                    programCounter++;
                }
                else if (parameter == "EF" || parameter == "ef" || parameter == "76")
                {
                    // RST 5 & HLT
                    Console.WriteLine("Halt Called");
                    break;
                }
                else if (parameter == "37")
                {
                    // STC
                    Console.WriteLine("STC Called");
                    flag.setFlagCY();
                    programCounter++;
                }
                else if (parameter == "3F" || parameter == "3f")
                {
                    // CMC
                    Console.WriteLine("CMC Called");
                    flag.FlagCY = !(flag.FlagCY);
                    programCounter++;
                }
                else if (parameter == "2F" || parameter == "2f")
                {
                    // CMA
                    Console.WriteLine("CMA Called");
                    register.RegA = alu.comp(register.RegA);
                    programCounter++;
                }
                else if (iSet.inrSet.ContainsKey(parameter))
                {
                    alu.Increment(iSet.inrSet[parameter]);
                    programCounter++;
                }
                else if (iSet.dcrSet.ContainsKey(parameter))
                {
                    alu.Decrement(iSet.dcrSet[parameter]);
                    programCounter++;
                }
                else if (iSet.anaSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    int count = alu.AND(iSet.anaSet[parameter], parameters[0]);
                    flag.setFlagAC();
                    flag.resetFlagCY();
                    alu.checkParityAndZero(register.RegA);
                    programCounter += count;
                }
                else if (iSet.oraSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    int count = alu.OR(iSet.oraSet[parameter], parameters[0]);
                    flag.resetFlagAC();
                    flag.resetFlagCY();
                    alu.checkParityAndZero(register.RegA);
                    programCounter += count;
                }
                else if (iSet.xraSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    int count = alu.XOR(iSet.xraSet[parameter], parameters[0]);
                    flag.resetFlagAC();
                    flag.resetFlagCY();
                    alu.checkParityAndZero(register.RegA);
                    programCounter += count;
                }
                else if (iSet.rotSet.ContainsKey(parameter))
                {
                    rt.rotInt(iSet.rotSet[parameter]);
                    programCounter++;
                }
                else if (iSet.jumpSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
                    programCounter = br.JUMP(iSet.jumpSet[parameter], parameters, programCounter);
                }
                else if (iSet.callSet.ContainsKey(parameter))
                {
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
                    programCounter = br.CALL(iSet.callSet[parameter], parameters, programCounter);
                }
                else if (parameter == "cd" || parameter == "CD")
                {
                    Console.WriteLine("CALL Called");
                    parameters[0] = codeHistory[Convert.ToString((programCounter + 1), 16)];
                    parameters[1] = codeHistory[Convert.ToString((programCounter + 2), 16)];
                    string temp = parameters[1] + parameters[0];
                    string temp1 = Convert.ToString(programCounter + 3, 16);
                    //stack.Push(temp1);
                    string temp2 = temp1.Substring(0, 2);
                    string temp3 = temp1.Substring(2, 2);
                    stack.Push(temp3);
                    stack.Push(temp2);
                    programCounter = Convert.ToInt32(temp, 16);
                }
                else if (iSet.retSet.ContainsKey(parameter))
                {
                    programCounter = br.RET(iSet.retSet[parameter]);
                }
                else if (parameter == "c9" || parameter == "C9")
                {
                    Console.WriteLine("RET Called");
                    string temp1 = stack.Pop().PadLeft(2, '0');
                    string temp2 = stack.Pop().PadLeft(2, '0');
                    //string temp = stack.Pop();
                    string temp = temp1 + temp2;
                    programCounter = Convert.ToInt32(temp, 16);
                }
                else
                {
                    Console.WriteLine("Not yet updated.");
                    programCounter++;
                }
                registers["A"] = Convert.ToString(register.RegA, 16).PadLeft(2, '0');
                registers["B"] = Convert.ToString(register.RegB, 16).PadLeft(2, '0');
                registers["C"] = Convert.ToString(register.RegC, 16).PadLeft(2, '0');
                registers["D"] = Convert.ToString(register.RegD, 16).PadLeft(2, '0');
                registers["E"] = Convert.ToString(register.RegE, 16).PadLeft(2, '0');
                registers["H"] = Convert.ToString(register.RegH, 16).PadLeft(2, '0');
                registers["L"] = Convert.ToString(register.RegL, 16).PadLeft(2, '0');
                registers["M"] = Convert.ToString(register.RegM, 16).PadLeft(2, '0'); 
                //registers["A"] = Convert.ToString(register.RegA, 16).Substring(0, 2);
                //registers["B"] = Convert.ToString(register.RegB, 16).Substring(0, 2);
                //registers["C"] = Convert.ToString(register.RegC, 16).Substring(0, 2);
                //registers["D"] = Convert.ToString(register.RegD, 16).Substring(0, 2);
                //registers["E"] = Convert.ToString(register.RegE, 16).Substring(0, 2);
                //registers["H"] = Convert.ToString(register.RegH, 16).Substring(0, 2);
                //registers["L"] = Convert.ToString(register.RegL, 16).Substring(0, 2);
                //registers["M"] = Convert.ToString(register.RegM, 16).Substring(0, 2);
                flags["S"] = Convert.ToString(Convert.ToInt32(flag.FlagS));
                flags["Z"] = Convert.ToString(Convert.ToInt32(flag.FlagZ));
                flags["AC"] = Convert.ToString(Convert.ToInt32(flag.FlagAC));
                flags["P"] = Convert.ToString(Convert.ToInt32(flag.FlagP));
                flags["CY"] = Convert.ToString(Convert.ToInt32(flag.FlagCY));
                //updateRegisters();
            }
        }
        public string getInitAddress(Dictionary<string, string> dict)
        {
            string? temp = null;
            foreach (var kvp in dict)
            {
                temp = kvp.Key;
                break;
            }
            return temp;
        }
        //public void updateRegisters()
        //{
        //    register.RegA = Convert.ToInt32(Convert.ToString(register.RegA, 16).Substring(0, 2));
        //    register.RegB = Convert.ToInt32(Convert.ToString(register.RegB, 16).Substring(0, 2));
        //    register.RegC = Convert.ToInt32(Convert.ToString(register.RegC, 16).Substring(0, 2));
        //    register.RegD = Convert.ToInt32(Convert.ToString(register.RegD, 16).Substring(0, 2));
        //    register.RegE = Convert.ToInt32(Convert.ToString(register.RegE, 16).Substring(0, 2));
        //    register.RegH = Convert.ToInt32(Convert.ToString(register.RegH, 16).Substring(0, 2));
        //    register.RegL = Convert.ToInt32(Convert.ToString(register.RegL, 16).Substring(0, 2));
        //    register.RegM = Convert.ToInt32(Convert.ToString(register.RegM, 16).Substring(0, 2));
        //}
        public void showRegandFlag()
        {
            Console.WriteLine();
            Console.WriteLine("Registers:\t\tFlags:");
            Console.WriteLine($"A: {Convert.ToString(register.RegA, 16).PadLeft(2, '0').ToUpper()}\t\t\tS:\t{Convert.ToInt16(flag.FlagS)}");
            Console.WriteLine($"B: {Convert.ToString(register.RegB, 16).PadLeft(2, '0').ToUpper()}\t\t\tZ:\t{Convert.ToInt16(flag.FlagZ)}");
            Console.WriteLine($"C: {Convert.ToString(register.RegC, 16).PadLeft(2, '0').ToUpper()}\t\t\tAC:\t{Convert.ToInt16(flag.FlagAC)}");
            Console.WriteLine($"D: {Convert.ToString(register.RegD, 16).PadLeft(2, '0').ToUpper()}\t\t\tP:\t{Convert.ToInt16(flag.FlagP)}");
            Console.WriteLine($"E: {Convert.ToString(register.RegE, 16).PadLeft(2, '0').ToUpper()}\t\t\tCY:\t{Convert.ToInt16(flag.FlagCY)}");
            Console.WriteLine($"H: {Convert.ToString(register.RegH, 16).PadLeft(2, '0').ToUpper()}");
            Console.WriteLine($"L: {Convert.ToString(register.RegL, 16).PadLeft(2, '0').ToUpper()}");
        }
    }
}
