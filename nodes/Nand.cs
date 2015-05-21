using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class Nand : Node
    {
        public Nand() : base()
        {

        }


        public static void registerSelf()
        {
            NodeFactory.register("NAND", typeof(Nand));
        }

    }
}
