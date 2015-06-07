using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simulatie1.readers
{
    public class TextFileReader: Reader
    {
        private Dictionary<string, string> nodes;
        private Dictionary<string, string[]> connections;
        private bool readingNodes;

        private List<Node> createdNodes;

        public TextFileReader()
        {
            this.readingNodes = true;
            this.nodes = new Dictionary<string, string>();
            this.connections = new Dictionary<string, string[]>();
            this.createdNodes = new List<Node>();
        }

        public static void registerSelf()
        {
            ReaderFactory.register("txt", typeof(TextFileReader));
        }

        public override List<Node> read()
        {
            string[] lines = System.IO.File.ReadAllLines(this.getPath());
            for (int x = 0; x < lines.Length; x++)
            {
                lines[x] = Regex.Replace(lines[x], @"\s+", "");
                //Lees connections uit
                if (!readingNodes && !lines[x][0].Equals('#'))
                {
                    char[] splitChar = { ':', ';' };
                    string[] node = lines[x].Split(splitChar);
                    char[] newSplitChar = { ',' };
                    string[] nodeConnections = node[1].Split(newSplitChar);
                    connections.Add(node[0], nodeConnections);
                }
                //Lees nodes uit
                else if (!String.IsNullOrEmpty(lines[x]) && !lines[x][0].Equals('#'))
                {
                    char[] splitChar = { ':', ';' };
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
                createdNodes.Add(nodefactory.createNode(node.Value, node.Key));
            }
            this.linkNodes();

            return this.createdNodes;
        }

        private void linkNodes()
        {
            foreach (Node node in createdNodes)
            {
                //If the current node is not an output
                if (!node.getType().Equals("PROBE"))
                {
                    if (connections.ContainsKey(node.getName()))
                    {
                        String[] myConnections = connections[node.getName()];
                        for (int y = 0; y < myConnections.Length; y++)
                        {
                            Node connection = this.createdNodes.Find(x => x.getName().Equals(myConnections[y]));
                            //Add connection to the current node
                            node.addConnection(connection);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Node: " + node.getName() + " heeft geen output.");
                    }
                }
            }
        }
    }
}
