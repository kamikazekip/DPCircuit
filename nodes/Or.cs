using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class Or : Node
    {
        public Or(): base()
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("OR", typeof(Or));
        }
    }
}
