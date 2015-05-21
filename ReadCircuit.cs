using Simulatie1.inputs;
using Simulatie1.operations;
using Simulatie1.outputs;
using System;
using System.Collections.Generic;
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
        public ReadCircuit()
        {
            readingNodes = true;
            nodes = new Dictionary<string, string>();
            connections = new Dictionary<string, string[]>();

            string[] lines = System.IO.File.ReadAllLines(@"D:\AVANS\Blok_12\DesignPatterns\Simulatie1\Simulatie1\bin\Debug\circuit1.txt");
            for (int x = 0; x < lines.Length; x++) {
                lines[x] = Regex.Replace(lines[x], @"\s+", "");
                //Lees connections uit
                if (!readingNodes && !lines[x][0].Equals('#'))
                {
                    char[] splitChar = {':'};
                    string[] node = lines[x].Split(splitChar);
                    char[] newSplitChar = {',', ';'};
                    string[] nodeConnections = node[1].Split(newSplitChar);
                    connections.Add(node[0], nodeConnections);
                    Console.WriteLine("Name: " + node[0] + " Connections: " + nodeConnections);
                }
                //Lees nodes uit
                else if (!String.IsNullOrEmpty(lines[x]) && !lines[x][0].Equals('#'))
                {
                    char[] splitChar = {':',';'};
                    string[] node = lines[x].Split(splitChar);
                    nodes.Add(node[0], node[1]);
                    Console.WriteLine("Name: " + node[0] + " Type: " + node[1]);
                }
                else if (String.IsNullOrEmpty(lines[x]))
                {
                    readingNodes = false;
                }
            }
            NodeFactory nodefactory = new NodeFactory();

            Node n= nodefactory.createNode("PROBE");
            
        }
    }
}
