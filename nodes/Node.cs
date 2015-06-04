using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public abstract class Node
    {
        private int numberOfInputs;
        private List<int> receivedNumbers;
        private List<Node> connections;
        private String name;

        public Node(int numberOfInputs)
        {
            this.numberOfInputs = numberOfInputs;
            this.receivedNumbers = new List<int>();
            this.connections = new List<Node>();
        }

        public void receiveNumber(int receivedNumber)
        {
            receivedNumbers.Add(receivedNumber);

            if (receivedNumbers.Count == numberOfInputs)
            {
                this.evaluate();
            }
            else if (receivedNumbers.Count > numberOfInputs)
            {
                Console.WriteLine(this.getName() + " zit in een oneindige loop. Kan circuit niet afmaken.");
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

        public List<Node> getConnections()
        {
            return this.connections;
        }

        public List<int> getReceivedNumbers()
        {
            return this.receivedNumbers;
        }

        public void reset()
        {
            this.receivedNumbers = new List<int>();
        }
        
        //Meant to be overridden
        public abstract void evaluate();

        public virtual void pass(int output)
        {
            foreach (Node connection in this.connections)
            {
                connection.receiveNumber(output);
            }
        }
    }
}
