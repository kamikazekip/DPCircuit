using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class Or : Node
    {
        public Or(): base(2)
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("OR", typeof(Or));
        }

        public override void evaluate()
        {
            int inputA = this.getReceivedNumbers()[0];
            int inputB = this.getReceivedNumbers()[1];
            if (inputA == 0 && inputB == 0)
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
