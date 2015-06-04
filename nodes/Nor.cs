using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    class NOr : Node
    {
        public NOr() : base (2)
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("NOR", typeof(NOr));
        }

        public override void evaluate()
        {
            int inputA = this.getReceivedNumbers()[0];
            int inputB = this.getReceivedNumbers()[1];
            if (inputA == 0 && inputB == 0)
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
