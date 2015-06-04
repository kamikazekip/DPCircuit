using Simulatie1.operations;
using Simulatie1.inputs;
using Simulatie1.outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulatie1.nodes;

namespace Simulatie1
{
    public class NodeFactory
    {
        private static Dictionary<string, Type> objects;

        public NodeFactory()
        {
            objects = new Dictionary<string, Type>();
            Input.registerSelf();
            And.registerSelf();
            Or.registerSelf();
            Not.registerSelf();
            NAnd.registerSelf();
            NOr.registerSelf();
            XOr.registerSelf();
            Output.registerSelf();
        }

        public Node createNode(string key, string name)
        {
           Node newNode = (Node) Activator.CreateInstance(objects[key]);
           newNode.setName(name);
           return newNode;
        }

        public static void register(String className, Type c)
        {
            objects.Add(className, c);
        }
    }
}
