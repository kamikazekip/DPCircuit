using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.readers
{
    public class XMLFileReader : Reader
    {
        public static void registerSelf()
        {
            ReaderFactory.register("xml", typeof(XMLFileReader));
        }

        public override List<Node> read()
        {
            Console.WriteLine("XMLFileReader heeft nog geen implementatie van Read(), enkel voor demo doeleinden!");
            return new List<Node>();
        }
    }
}
