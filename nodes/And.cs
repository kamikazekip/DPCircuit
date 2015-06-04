using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class And : Node
    {
        public And() : base (2)
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("AND", typeof(And));
        }

        public override void evaluate()
        {
            int inputA = this.getReceivedNumbers()[0];
            int inputB = this.getReceivedNumbers()[1];
            if (inputA == 1 && inputB == 1)
            {
                this.pass(1);
            }
            else
            {
                this.pass(0);
            }
        }
    }
}
