using Simulatie1.readers;
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
            ReaderFactory readerFactory = new ReaderFactory();
            Reader reader = readerFactory.createReader(@"C:\Users\Jip\Documents\School\DP1\DPCircuit\bin\Debug\circuit4.txt");
            NodeCircuit circuit = new NodeCircuit();
            circuit.startCircuit(reader);
            Console.ReadLine();
        }
    }
}
