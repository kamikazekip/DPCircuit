using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.inputs
{
    public class Input : Node
    {
        public Input() : base(1)
        {
            
        }

        public static void registerSelf()
        {
            NodeFactory.register("INPUT_HIGH", typeof(Input));
            NodeFactory.register("INPUT_LOW", typeof(Input));
        }

        public override void evaluate()
        {
            int output = this.getReceivedNumbers()[0];
            this.pass(output);
        }
    }
}
