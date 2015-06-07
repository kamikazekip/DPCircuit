using Simulatie1.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.readers
{
    public abstract class Reader
    {
        private String path;
        public abstract List<Node> read();

        public void setPath(String path)
        {
            this.path = path;
        }

        public String getPath()
        {
            return this.path;
        }
    }
}
