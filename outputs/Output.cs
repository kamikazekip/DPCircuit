using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.outputs
{
    public class Output
    {
        private String name;

        public Output(String name)
        {
            this.name = name;
        }

        public void write(int number){
            Console.WriteLine(name + ": " + number );
        }
    }
}
