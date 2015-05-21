using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class And : Node
    {
        public And() : base ()
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("AND", typeof(And));
        }
    }
}
