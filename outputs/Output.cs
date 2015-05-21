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
        public Output() : base()
        {
            
        }

        public static void registerSelf()
        {
            NodeFactory.register("PROBE", typeof(Output));
        }
    }
}
