using Simulatie1.readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReaderFactory readerFactory = new ReaderFactory();
            string executableLocation = Path.GetDirectoryName(
             Assembly.GetExecutingAssembly().Location);
            string circuitLocation = Path.Combine(executableLocation, "circuit1.txt");
            Console.WriteLine(circuitLocation);
            Reader reader = readerFactory.createReader(circuitLocation);
            NodeCircuit circuit = new NodeCircuit();
            circuit.startCircuit(reader);
            Console.ReadLine();
        }
    }
}
