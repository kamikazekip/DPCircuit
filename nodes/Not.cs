﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class Not : Node
    {
        public Not() : base(1)
        {

        }

        public static void registerSelf()
        {
            NodeFactory.register("NOT", typeof(Not));
        }

        public override void evaluate()
        {
            int inputA = this.getReceivedNumbers()[0];
            if (inputA == 0)
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
