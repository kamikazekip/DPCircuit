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

namespace Simulatie1
{
    public class NodeCircuit
    {
        private Dictionary<string, string> nodes;
        private Dictionary<string, string[]> connections;
        private bool readingNodes;

        private Dictionary<string, Node> createdNodes;

        public NodeCircuit(){
            readingNodes = true;
            nodes = new Dictionary<string, string>();
            connections = new Dictionary<string, string[]>();
            createdNodes = new Dictionary<string, Node>();
        }

        public void startCircuit(String circuit)
        {
            string[] lines = System.IO.File.ReadAllLines(circuit);
            for (int x = 0; x < lines.Length; x++) {
                lines[x] = Regex.Replace(lines[x], @"\s+", "");
                //Lees connections uit
                if (!readingNodes && !lines[x][0].Equals('#'))
                {
                    char[] splitChar = {':', ';'};
                    string[] node = lines[x].Split(splitChar);
                    char[] newSplitChar = {','};
                    string[] nodeConnections = node[1].Split(newSplitChar);
                    connections.Add(node[0], nodeConnections);
                }
                //Lees nodes uit
                else if (!String.IsNullOrEmpty(lines[x]) && !lines[x][0].Equals('#'))
                {
                    char[] splitChar = {':',';'};
                    string[] node = lines[x].Split(splitChar);
                    nodes.Add(node[0], node[1]);
                }
                else if (String.IsNullOrEmpty(lines[x]))
                {
                    readingNodes = false;
                }
            }
            NodeFactory nodefactory = new NodeFactory();
            foreach (KeyValuePair<string, string> node in nodes)
            {
                createdNodes.Add(node.Key, nodefactory.createNode(node.Value, node.Key));
            }

            linkNodes();
        }

        private void linkNodes()
        {
            foreach (KeyValuePair<string, Node> node in createdNodes)
            {
                //If the current node is not an output
                if(!nodes[node.Key].Equals("PROBE")){
                    if (connections.ContainsKey(node.Key))
                    {
                        String[] myConnections = connections[node.Key];
                        for (int y = 0; y < myConnections.Length; y++)
                        {
                            //Add connection to the current node
                            node.Value.addConnection(createdNodes[myConnections[y]]);
                        }
                    }
                    else {
                        Console.WriteLine("Node: " + node.Key + " heeft geen output.");
                    }
                }
            }
            assignInputs();
        }

        private void assignInputs()
        {
            foreach (KeyValuePair<string, Node> node in createdNodes)
            {
                if (node.Value is Input)
                {
                    if(nodes[node.Key].Equals("INPUT_HIGH")){
                        Console.WriteLine(node.Value.getName() + " ( Input ) is: 1");
                        node.Value.receiveNumber(1);
                    } else {
                        Console.WriteLine(node.Value.getName() + " ( Input ) is: 0");
                        node.Value.receiveNumber(0);
                    }
                }
            }
            done();
        }

        private void done()
        {
            Console.WriteLine("");
            foreach (KeyValuePair<string, Node> node in createdNodes)
            {
                node.Value.reset();
            }
            Console.WriteLine("Als u het opnieuw wilt proberen, vult u de cijfers in");
            foreach (KeyValuePair<string, Node> node in createdNodes)
            {
                if (node.Value is Input)
                {
                    Console.WriteLine("Geef nummer ( 0 of 1 ) op voor " + node.Value.getName() + ":");
                    node.Value.receiveNumber(getInput());
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
