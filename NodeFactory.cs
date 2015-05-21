using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1
{
    public class NodeFactory
    {
        private static Dictionary<string, Type> objects;

        public NodeFactory()
        {
            objects = new Dictionary<string, Type>();
        }

        public Node createNode(string key)
        {
            return (Node)Activator.CreateInstance(objects[key]);
        }

        public static void register(String className, Type c)
        {
            objects.Add(className, c);
        }
    }
}
