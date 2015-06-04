using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.nodes
{
    public class XOr : Node
    {
        public XOr()
            : base(2)
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("XOR", typeof(XOr));
        }

        public override void evaluate()
        {
            int inputA = this.getReceivedNumbers()[0];
            int inputB = this.getReceivedNumbers()[1];
            if (inputA == inputB)
            {
                this.pass(0);
            }
            else
            {
                this.pass(1);
            }
        }
    }
}
