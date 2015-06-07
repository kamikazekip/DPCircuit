using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.readers
{
    public class JSONFileReader : Reader
    {
        public static void registerSelf()
        {
            ReaderFactory.register("json", typeof(JSONFileReader));
        }

        public override List<Node> read()
        {
            Console.WriteLine("JSONFileReader heeft nog geen implementatie van Read(), enkel voor demo doeleinden!");
            return new List<Node>();
        }
    }
}
