using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class Node
    {
        private int numberOfInputs;
        private List<int> numbers;
        private List<Node> connections;
        private String name;

        public Node()
        {
            this.numbers = new List<int>();
            this.connections = new List<Node>();
        }

        public void giveNumber(int givenNumber)
        {
            numbers.Add(givenNumber);

            if (numbers.Count == numberOfInputs)
            {
                //Evaluate
            }
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public void setNumberOfInputs(int inputs)
        {
            this.numberOfInputs = inputs;
        }

        public int getNumberOfInputs()
        {
            return this.numberOfInputs;
        }

        public void addConnection(Node node)
        {
            this.connections.Add(node);
        }
    }
}
