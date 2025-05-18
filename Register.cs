using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MicroSim
{
    internal class Registers
    {
        public Registers()
        {
            RegA = RegB = RegA = RegB = RegE = PSW = RegH = RegL = RegM = 0x00;
        }
        public int RegA { get; set; }
        public int RegB { get; set; }
        public int RegC { get; set; }
        public int RegD { get; set; }
        public int RegE { get; set; }
        public int PSW { get; set; }
        public int RegH { get; set; }
        public int RegL { get; set; }
        public int RegM { get; set; }
        public void showValue()
        {
            Console.WriteLine();
            Console.WriteLine("Registers:");
            Console.WriteLine($"A: {Convert.ToString(RegA, 16).PadLeft(2, '0').ToUpper()}");
            Console.WriteLine($"B: {Convert.ToString(RegB, 16).PadLeft(2, '0').ToUpper()}");
            Console.WriteLine($"C: {Convert.ToString(RegC, 16).PadLeft(2, '0').ToUpper()}");
            Console.WriteLine($"D: {Convert.ToString(RegD, 16).PadLeft(2, '0').ToUpper()}");
            Console.WriteLine($"E: {Convert.ToString(RegE, 16).PadLeft(2, '0').ToUpper()}");
            Console.WriteLine($"H: {Convert.ToString(RegH, 16).PadLeft(2, '0').ToUpper()}");
            Console.WriteLine($"L: {Convert.ToString(RegL, 16).PadLeft(2, '0').ToUpper()}");
        }
    }
}