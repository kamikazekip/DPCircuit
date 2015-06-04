using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1
{
    public class Program
    {
        static void Main(string[] args)
        {
            NodeCircuit circuit = new NodeCircuit();
            circuit.startCircuit(@"C:\Users\Jip\Documents\School\DP1\DPCircuit\bin\Debug\circuit1.txt");
            Console.ReadLine();
        }
    }
}
