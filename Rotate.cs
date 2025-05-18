using System;

namespace MicroSim
{
    internal class Rotate
    {
        private Node head;
        private Registers register;
        private Flags flag;

        public Rotate(Registers register, Flags flag)
        {
            head = null;
            this.register = register;
            this.flag = flag;
        }
        public void InsertBeg(string val)
        {
            Node newNode = new Node(val);
            if (head == null)
            {
                head = newNode;
                return;
            }
            Node temp = head;
            head = newNode;
            newNode.Next = temp;
        }
        public void rotInt(string parameter)
        {
            string c = Convert.ToString(Convert.ToInt32(flag.FlagCY));
            string rega = Convert.ToString(register.RegA, 2).PadLeft(8, '0');
            for (int i = 0; i < 8; i++)
                InsertBeg(rega[i].ToString());
            switch (parameter)
            {
                case "RLC":
                    RotateLeft();
                    break;
                case "RRC":
                    RotateRight(c);
                    break;
                case "RAL":
                    RotateLeftThroughCarry(c);
                    break;
                case "RAR":
                    RotateRightThroughCarry(c);
                    break;
                default:
                    break;
            }

        }
        public void RotateLeftThroughCarry(string carry)
        {
            if (head != null)
            {
                Node lastNode = head;
                Node secondLastNode = null;
                while (lastNode.Next != null)
                {
                    secondLastNode = lastNode;
                    lastNode = lastNode.Next;
                }

                if (secondLastNode != null)
                {
                    string rotatedValue = lastNode.Data;
                    lastNode.Data = carry;
                    carry = rotatedValue; // Update carry with the rotated bit
                    secondLastNode.Next = null;
                    lastNode.Next = head;
                    head = lastNode;
                    flag.FlagCY = Convert.ToBoolean(Convert.ToInt32(carry));
                    register.RegA = Convert.ToInt32(GetBinaryOutput().Substring(0, 8), 2);
                }
            }
        }
        public void RotateLeft()
        {
            if (head != null)
            {
                Node lastNode = head;
                Node secondLastNode = null;
                while (lastNode.Next != null)
                {
                    secondLastNode = lastNode;
                    lastNode = lastNode.Next;
                }
                if (secondLastNode != null)
                {
                    string rotatedValue = lastNode.Data;
                    string carry = rotatedValue;
                    lastNode.Data = rotatedValue;
                    secondLastNode.Next = null;
                    lastNode.Next = head;
                    head = lastNode;
                    flag.FlagCY = Convert.ToBoolean(Convert.ToInt32(carry));
                    register.RegA = Convert.ToInt32(GetBinaryOutput().Substring(0, 8), 2);
                }
            }
        }

        public void RotateRight(string carry)
        {
            if (head != null)
            {
                Node firstNode = head;
                string rotatedValue = firstNode.Data;
                firstNode.Data = carry;
                carry = rotatedValue;
                head = head.Next;

                Node lastNode = head;
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }

                lastNode.Next = firstNode;
                firstNode.Next = null;
            }
            flag.FlagCY = Convert.ToBoolean(Convert.ToInt32(carry));
            register.RegA = Convert.ToInt32(GetBinaryOutput().Substring(0, 8), 2);
        }
        public void RotateRightThroughCarry(string carry)
        {
            if (head != null)
            {
                Node lastNode = head;
                Node secondLastNode = null;

                while (lastNode.Next != null)
                {
                    secondLastNode = lastNode;
                    lastNode = lastNode.Next;
                }

                // Move each node's data to the next node
                while (lastNode != head)
                {
                    //lastNode.Data = secondLastNode.Data;
                    lastNode = secondLastNode;
                    //secondLastNode = secondLastNode.Next;
                }

                // Update the first node with the carry value
                head.Data = carry;

                flag.FlagCY = Convert.ToBoolean(Convert.ToInt32(carry));
                register.RegA = Convert.ToInt32(GetBinaryOutput().Substring(0, 8), 2);
            }
        }


        public string GetBinaryOutput()
        {
            Node temp = head;
            string binaryOutput = "";
            while (temp != null)
            {
                binaryOutput = temp.Data + binaryOutput;
                temp = temp.Next;
            }

            // Pad with leading zeros to make it eight bits
            return binaryOutput.PadLeft(8, '0');
        }
    }
}
