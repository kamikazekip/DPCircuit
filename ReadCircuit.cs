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
    public class ReadCircuit
    {
        private Dictionary<string, string> nodes;
        private Dictionary<string, string[]> connections;
        private bool readingNodes;

        private Dictionary<string, Node> createdNodes;

        public ReadCircuit()
        {
            readingNodes = true;
            nodes = new Dictionary<string, string>();
            connections = new Dictionary<string, string[]>();

            createdNodes = new Dictionary<string, Node>();

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jip\Documents\School\DP1\DPCircuit\bin\Debug\circuit1.txt");
            for (int x = 0; x < lines.Length; x++) {
                lines[x] = Regex.Replace(lines[x], @"\s+", "");
                //Lees connections uit
                if (!readingNodes && !lines[x][0].Equals('#'))
                {
                    char[] splitChar = {':', ';'};
                    string[] node = lines[x].Split(splitChar);
                    char[] newSplitChar = {','};
                    string[] nodeConnections = node[1].Split(newSplitChar);
                    for (int y = 0; y < nodeConnections.Length; y++)
                    {
                        Console.WriteLine(nodeConnections[y]);
                    }
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

            Console.WriteLine("");
            linkNodes();
        }

        private void linkNodes()
        {
            foreach (KeyValuePair<string, Node> node in createdNodes)
            {
                //If the current node is not an output
                if(!nodes[node.Key].Equals("PROBE")){
                    String[] myConnections = connections[node.Key];
                    for (int y = 0; y < myConnections.Length; y++)
                    {
                        //Add connection to the current node
                        node.Value.addConnection(createdNodes[myConnections[y]]);
                    }
                }
            }
            //Alle nodes zijn op dit moment gemaakt en aan elkaar gelinkt
        }
    }
}
