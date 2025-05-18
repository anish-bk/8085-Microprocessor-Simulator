using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim
{
    public class Node
    {
        public string Data;
        public Node Next;

        public Node()
        {
        }

        public Node(string data)
        {
            Data = data;
            Next = null;
        }
    }
}
