using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    class Nor : Node
    {
        public Nor() : base ()
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("NOR", typeof(Nor));
        }

    }
}
