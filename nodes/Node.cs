using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulatie1.operations
{
    public class Node
    {
        public int numberOfInputs;
        public List<int> numbers;

        public Node(int numberOfInputs)
        {
            this.numberOfInputs = numberOfInputs;
            this.numbers = new List<int>();
        }

        public void giveNumber(int givenNumber)
        {
            numbers.Add(givenNumber);

            if (numbers.Count == numberOfInputs)
            {
                //Evaluate
            }
        }

    }
}
