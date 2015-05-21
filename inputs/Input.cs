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
        public Input() : base()
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("INPUT_HIGH", typeof(Input));
            NodeFactory.register("INPUT_LOW", typeof(Input));
        }    
    }
}
