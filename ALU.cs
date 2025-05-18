using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim
{
    internal class ALU
    {
        private Registers register = new Registers();
        private Flags flag = new Flags();
        public ALU(Registers register, Flags flag)
        {
            this.register = register;
            this.flag = flag;
        }
        public int Addition(string parameter1, string value)
        {
            Console.WriteLine("Addition Called");
            switch (parameter1)
            {
                case "A":
                    register.RegA = add(register.RegA, register.RegA);
                    return 1;
                case "B":
                    register.RegA = add(register.RegA, register.RegB);
                    return 1;
                case "C":
                    register.RegA = add(register.RegA, register.RegC);
                    return 1;
                case "D":
                    register.RegA = add(register.RegA, register.RegD);
                    return 1;
                case "E":
                    register.RegA = add(register.RegA, register.RegE);
                    return 1;
                case "H":
                    register.RegA = add(register.RegA, register.RegH);
                    return 1;
                case "L":
                    register.RegA = add(register.RegA, register.RegL);
                    return 1;
                case "M":
                    register.RegA = add(register.RegA, register.RegM);
                    return 1;
                case "I":
                    int temp = Convert.ToInt32(value, 16);
                    register.RegA = add(register.RegA, temp);
                    return 2;
                default:
                    return 1;
            }
        }
        public int AdditionWithCarry(string parameter1, string value)
        {
            Console.WriteLine("AdditionWithCarry Called");
            int carry = Convert.ToInt16(flag.FlagCY);
            switch (parameter1)
            {
                case "A":
                    register.RegA = add(add(register.RegA, carry), register.RegA);
                    return 1;
                case "B":
                    register.RegA = add(add(register.RegA, carry), register.RegB);
                    return 1;
                case "C":
                    register.RegA = add(add(register.RegA, carry), register.RegC);
                    return 1;
                case "D":
                    register.RegA = add(add(register.RegA, carry), register.RegD);
                    return 1;
                case "E":
                    register.RegA = add(add(register.RegA, carry), register.RegE);
                    return 1;
                case "H":
                    register.RegA = add(add(register.RegA, carry), register.RegH);
                    return 1;
                case "L":
                    register.RegA = add(add(register.RegA, carry), register.RegL);
                    return 1;
                case "M":
                    register.RegA = add(add(register.RegA, carry), register.RegM);
                    return 1;
                case "I":
                    int temp = Convert.ToInt32(value, 16);
                    register.RegA = add(add(register.RegA, carry), temp);
                    return 2;
                default:
                    return 1;
            }
        }
        public void Subtraction(string parameter1)
        {
            Console.WriteLine("Subtraction Called");
            int temp;
            switch (parameter1)
            {
                case "A":
                    register.RegA -= register.RegA;
                    return;
                case "B":
                    if (register.RegA < register.RegB)
                    {
                        temp = register.RegB;
                        register.RegB = register.RegA;
                        register.RegA = temp;
                        flag.setFlagCY();
                    }
                    register.RegA -= register.RegB;
                    return;
                case "C":
                    if (register.RegA < register.RegC)
                    {
                        temp = register.RegC;
                        register.RegC = register.RegA;
                        register.RegA = temp;
                        flag.setFlagCY();
                    }
                    register.RegA -= register.RegC;
                    return;
                case "D":
                    if (register.RegA < register.RegD)
                    {
                        temp = register.RegD;
                        register.RegD = register.RegA;
                        register.RegA = temp;
                        flag.setFlagCY();
                    }
                    register.RegA -= register.RegD;
                    return;
                case "E":
                    if (register.RegA < register.RegE)
                    {
                        temp = register.RegE;
                        register.RegE = register.RegA;
                        register.RegA = temp;
                        flag.setFlagCY();
                    }
                    register.RegA -= register.RegE;
                    return;
                case "H":
                    if (register.RegA < register.RegH)
                    {
                        temp = register.RegH;
                        register.RegH = register.RegA;
                        register.RegA = temp;
                        flag.setFlagCY();
                    }
                    register.RegA -= register.RegH;
                    return;
                case "L":
                    if (register.RegA < register.RegL)
                    {
                        temp = register.RegL;
                        register.RegL = register.RegA;
                        register.RegA = temp;
                        flag.setFlagCY();
                    }
                    register.RegA -= register.RegL;
                    return;
                case "M":
                    if (register.RegA < register.RegM)
                    {
                        temp = register.RegM;
                        register.RegM = register.RegA;
                        register.RegA = temp;
                        flag.setFlagCY();
                    }
                    register.RegA -= register.RegM;
                    return;
                default:
                    return;
            }
        }
        public void Increment(string parameter1)
        {
            Console.WriteLine("Increment Called");
            switch (parameter1)
            {
                case "A":
                    register.RegA = add(register.RegA, 1);
                    checkParityAndZero(register.RegA);
                    return;
                case "B":
                    register.RegB = add(register.RegB, 1);
                    checkParityAndZero(register.RegB);
                    return;
                case "C":
                    register.RegC = add(register.RegC, 1);
                    checkParityAndZero(register.RegC);
                    return;
                case "D":
                    register.RegD = add(register.RegD, 1);
                    checkParityAndZero(register.RegD);
                    return;
                case "E":
                    register.RegE = add(register.RegE, 1);
                    checkParityAndZero(register.RegE);
                    return;
                case "H":
                    register.RegH = add(register.RegH, 1);
                    checkParityAndZero(register.RegH);
                    return;
                case "L":
                    register.RegL = add(register.RegL, 1);
                    checkParityAndZero(register.RegL);
                    return;
                case "M":
                    register.RegM = add(register.RegM, 1);
                    checkParityAndZero(register.RegM);
                    return;
                default:
                    return;
            }
        }
        public void Decrement(string parameter1)
        {
            Console.WriteLine("Decrement Called");
            switch (parameter1)
            {
                case "A":
                    register.RegA--;
                    checkParityAndZero(register.RegA);
                    return;
                case "B":
                    register.RegB--;
                    checkParityAndZero(register.RegB);
                    return;
                case "C":
                    register.RegC--;
                    checkParityAndZero(register.RegC);
                    return;
                case "D":
                    register.RegD--;
                    checkParityAndZero(register.RegD);
                    return;
                case "E":
                    register.RegE--;
                    checkParityAndZero(register.RegE);
                    return;
                case "H":
                    register.RegH--;
                    checkParityAndZero(register.RegH);
                    return;
                case "L":
                    register.RegL--;
                    checkParityAndZero(register.RegL);
                    return;
                case "M":
                    register.RegM--;
                    checkParityAndZero(register.RegM);
                    return;
                default:
                    return;
            }
        }
        public int AND(string parameter1, string value)
        {
            Console.WriteLine("AND Called");
            switch (parameter1)
            {
                case "A":
                    register.RegA &= register.RegA;
                    return 1;
                case "B":
                    register.RegA &= register.RegB;
                    return 1;
                case "C":
                    register.RegA &= register.RegC;
                    return 1;
                case "D":
                    register.RegA &= register.RegD;
                    return 1;
                case "E":
                    register.RegA &= register.RegE;
                    return 1;
                case "H":
                    register.RegA &= register.RegH;
                    return 1;
                case "L":
                    register.RegA &= register.RegL;
                    return 1;
                case "M":
                    register.RegA &= register.RegM;
                    return 1;
                case "I":
                    int temp = Convert.ToInt32(value, 16);
                    register.RegA &= temp;
                    return 2;
                default:
                    return 1;
            }
        }
        public int OR(string parameter1, string value)
        {
            Console.WriteLine("OR Called");
            switch (parameter1)
            {
                case "A":
                    register.RegA |= register.RegA;
                    return 1;
                case "B":
                    register.RegA |= register.RegB;
                    return 1;
                case "C":
                    register.RegA |= register.RegC;
                    return 1;
                case "D":
                    register.RegA |= register.RegD;
                    return 1;
                case "E":
                    register.RegA |= register.RegE;
                    return 1;
                case "H":
                    register.RegA |= register.RegH;
                    return 1;
                case "L":
                    register.RegA |= register.RegL;
                    return 1;
                case "M":
                    register.RegA |= register.RegM;
                    return 1;
                case "I":
                    int temp = Convert.ToInt32(value, 16);
                    register.RegA |= temp;
                    return 2;
                default:
                    return 1;
            }
        }
        public int XOR(string parameter1, string value)
        {
            Console.WriteLine("XOR Called");
            switch (parameter1)
            {
                case "A":
                    register.RegA = Xor(register.RegA, register.RegA);
                    return 1;
                case "B":
                    register.RegA = Xor(register.RegA, register.RegB);
                    return 1;
                case "C":
                    register.RegA = Xor(register.RegA, register.RegC);
                    return 1;
                case "D":
                    register.RegA = Xor(register.RegA, register.RegD);
                    return 1;
                case "E":
                    register.RegA = Xor(register.RegA, register.RegE);
                    return 1;
                case "H":
                    register.RegA = Xor(register.RegA, register.RegH);
                    return 1;
                case "L":
                    register.RegA = Xor(register.RegA, register.RegL);
                    return 1;
                case "M":
                    register.RegA = Xor(register.RegA, register.RegM);
                    return 1;
                case "I":
                    int temp = Convert.ToInt32(value, 16);
                    register.RegA = Xor(register.RegA, temp);
                    return 2;
                default:
                    return 1;
            }
        }
        public int Xor(int a, int b)
        {
            return (a & comp(b)) | (comp(a) & b);
        }
        public int add(int param1, int param2)
        {
            Console.WriteLine("add Called");
            string hex1 = Convert.ToString(param1, 16).PadLeft(2, '0');
            string hex2 = Convert.ToString(param2, 16).PadLeft(2, '0');
            string[] array1 = parseString(hex1);
            string[] array2 = parseString(hex2);
            int[] intArray1 = new int[2];
            intArray1[0] = 0;
            intArray1[1] = 0;
            for (int i = 0; i < array1.Length; i++)
                intArray1[i] = Convert.ToInt32(array1[i], 16);
            int[] intArray2 = new int[2];
            for (int i = 0; i < array2.Length; i++)
                intArray2[i] = Convert.ToInt32(array2[i], 16);
            int[] resultArray = new int[2];
            resultArray[1] = (intArray1[1] + intArray2[1]) % 16;
            flag.FlagAC = ((intArray1[1] + intArray2[1]) / 16) == 1;
            resultArray[0] = (intArray1[0] + intArray2[0] + Convert.ToInt32(flag.FlagAC)) % 16;
            flag.FlagCY = ((intArray1[0] + intArray2[0] + Convert.ToInt32(flag.FlagAC)) / 16) == 1;
            string[] stringArray3 = new string[2];
            stringArray3[0] = Convert.ToString(resultArray[0], 16);
            stringArray3[1] = Convert.ToString(resultArray[1], 16);
            int result = Convert.ToInt32((stringArray3[0] + stringArray3[1]), 16);
            return result;
        }
        public int sub()
        {
            string carry = "0";
            string? auxiliaryCarry = "0";
            string? temp = "null";
            Console.WriteLine("Enter the string to be partitioned");
            //string? temp1=Console.ReadLine();
            temp = Console.ReadLine();
            string[] stringArray1 = new string[2];
            stringArray1[0] = "0";
            stringArray1[1] = "0";
            stringArray1 = parseString(temp);
            int[] intArray1 = new int[2];
            intArray1[0] = Convert.ToInt32(stringArray1[0], 16);
            intArray1[1] = Convert.ToInt32(stringArray1[1], 16);
            string? temp1 = "null";
            Console.WriteLine("Enter the string 2 to be partitioned");
            //string? temp1=Console.ReadLine();
            temp1 = Console.ReadLine();
            string[] stringArray2 = new string[2];
            stringArray2[0] = "0";
            stringArray2[1] = "0";
            stringArray2 = parseString(temp1);
            int[] intArray2 = new int[2];
            intArray2[0] = Convert.ToInt32(stringArray2[0], 16);
            intArray2[1] = Convert.ToInt32(stringArray2[1], 16);
            int[] intArray3 = new int[2];

            if (intArray1[1] > intArray2[1])
            {
                intArray3[1] = (intArray1[1] - intArray2[1]) % 16;
                flag.FlagAC = false;
            }
            else
            {
                intArray3[1] = (intArray1[1] + 16 - intArray2[1]) % 16;
                flag.FlagAC = true;
            }
            Console.WriteLine(intArray3[1]);
            if (intArray1[0] > intArray2[0])
            {
                intArray3[0] = (intArray1[0] - intArray2[0] - Convert.ToInt32(auxiliaryCarry, 16)) % 16;
                flag.FlagCY = false;
            }
            else
            {
                intArray3[0] = (intArray1[0] + 16 - intArray2[0] - Convert.ToInt32(auxiliaryCarry, 16)) % 16;
                flag.FlagCY = true;
            }
            string[] stringArray3 = new string[2];
            stringArray3[0] = Convert.ToString(intArray3[0], 16);
            stringArray3[1] = Convert.ToString(intArray3[1], 16);
            int result = Convert.ToInt32(stringArray3[0] + stringArray3[1], 16);
            return result;
        }

        public int comp(int temp)
        {
            string strTemp = Convert.ToString(temp, 16);
            string compTemp = Convert.ToString(~Convert.ToInt32(strTemp, 16), 16);
            string lastTwoBits = compTemp.Length >= 2 ? compTemp.Substring(compTemp.Length - 2) : compTemp;
            return Convert.ToInt32(lastTwoBits, 16);
        }
        public void checkParityAndZero(int reg)
        {
            string temp = Convert.ToString(reg, 2).PadLeft(8, '0');
            int count = 0;
            foreach (char bit in temp)
            {
                Console.Write(bit);
                if (bit == '1')
                    count++;
            }
            flag.FlagP = (count % 2 == 0);
            flag.FlagZ = (reg == 0);
            flag.FlagS = (temp[0] == '1');
        }
        static string[] parseString(string temp)
        {
            string[] x = new string[temp.Length];
            int i = 0;
            while (i < temp.Length)
            {
                string tempString = temp.Substring(i, 1);
                x[i] = tempString;
                i++;
            }
            return x;
        }
    }
}
