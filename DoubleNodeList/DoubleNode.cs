using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleNodeList
{
    public class DoubleNode
    {

        public DoubleNode()
        { }
        public DoubleNode (string data)
        {
            Data = data;
        }

        public string Data { get; set; }
        public DoubleNode Previous { get; set; }
        public DoubleNode Next { get; set; }

    }
}
