using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.inputs
{
    public class Input
    {
        private String name;
        private int number;
        private List<Node> nodes;

        public Input(String name, int number)
        {
            this.name = name;
            this.number = number;
            this.nodes = new List<Node>();
        }

        public void connectNode(Node node)
        {
            nodes.Add(node);
        }

        public void fire()
        {
            Console.Write(number);
            foreach(var node in nodes){
               node.giveNumber(number);
            }
        }
    }
}
