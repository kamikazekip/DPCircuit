using Simulatie1.readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1
{
    public class ReaderFactory
    {
        private static Dictionary<string, Type> objects;

        public ReaderFactory()
        {
            objects = new Dictionary<string, Type>();
            TextFileReader.registerSelf();
            JSONFileReader.registerSelf();
            XMLFileReader.registerSelf();
        }

        public Reader createReader(String circuit)
        {
           String[] extensionArray = circuit.Split('.');
           String extension = extensionArray[extensionArray.Length - 1];
           Reader newReader = (Reader) Activator.CreateInstance(objects[extension]);
           newReader.setPath(circuit);
           return newReader;
        }

        public static void register(String className, Type c)
        {
            objects.Add(className, c);
        }

    }
}
