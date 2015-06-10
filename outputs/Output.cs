using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.outputs
{
    public class Output : Node
    {
        private int output;

        public Output() : base(1)
        {
            
        }

        public static void registerSelf()
        {
            NodeFactory.register("PROBE", typeof(Output));
        }

        public override void evaluate()
        {
            var output = this.getReceivedNumbers()[0];
            this.pass(output);
        }

        public override void pass(int output)
        {
            this.output = output; // Alleen voor test doeleinden
            Console.WriteLine(this.getName() + " ( Output ) is: " + output);
        }

        public int getOutput()
        {
            return this.output;
        }

    }
}
