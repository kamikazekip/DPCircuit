using Simulatie1.inputs;
using Simulatie1.operations;
using Simulatie1.outputs;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Simulatie1.readers;

namespace Simulatie1
{
    public class NodeCircuit
    {
        private List<Node> nodes;

        //private Dictionary<string, string> nodes;
        private Dictionary<string, string[]> connections;
        private bool readingNodes;

        private Dictionary<string, Node> createdNodes;
        private Reader reader;

        public NodeCircuit(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public void startCircuit()
        {
            if (this.nodes.Count > 0)
            {
                this.assignInputs();
            }
        } 

        private void assignInputs()
        {
            foreach (Node node in this.nodes)
            {
                if (node is Input)
                {
                    if(node.getType().Equals("INPUT_HIGH")){
                        Console.WriteLine(node.getName() + " ( Input ) is: 1");
                        node.receiveNumber(1);
                    } else {
                        Console.WriteLine(node.getName() + " ( Input ) is: 0");
                        node.receiveNumber(0);
                    }
                }
            }
            done();
        }

        private void done()
        {
            Console.WriteLine("");
            foreach (Node node in this.nodes)
            {
                node.reset();
            }
            Console.WriteLine("Als u het opnieuw wilt proberen, vult u de cijfers in");
            foreach (Node node in this.nodes)
            {
                if (node is Input)
                {
                    Console.WriteLine("Geef nummer ( 0 of 1 ) op voor " + node.getName() + ":");
                    node.receiveNumber(getInput());
                }
            }
            done();
        }

        private int getInput()
        {
            string userInput = Console.ReadLine();
            int number;
            if (int.TryParse(userInput, out number))
            {
                if (number == 0 || number == 1) {
                    return number;
                }
            }
            Console.WriteLine("Non a valid input. Input must be 0 or 1. Try again.");
            getInput();
            return 10;
        }
    }
}
