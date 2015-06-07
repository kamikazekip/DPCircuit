using Simulatie1.operations;
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

            Console.WriteLine("Reading file: " + circuitLocation);
            Console.WriteLine("");

            Reader reader = readerFactory.createReader(circuitLocation);
            List<Node> nodes = reader.read();
            NodeCircuit circuit = new NodeCircuit(nodes);
            circuit.startCircuit();
            Console.ReadLine();
        }
    }
}
