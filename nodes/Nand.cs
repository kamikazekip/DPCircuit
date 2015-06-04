using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class NAnd : Node
    {
        public NAnd() : base(2)
        {

        }


        public static void registerSelf()
        {
            NodeFactory.register("NAND", typeof(NAnd));
        }

        public override void evaluate()
        {
            int inputA = this.getReceivedNumbers()[0];
            int inputB = this.getReceivedNumbers()[1];
            if (inputA == 1 && inputB == 1)
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
