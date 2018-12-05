using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.model
{
    public class BoolVector
    {
        private List<int> components;

        public BoolVector()
        {
        }

        public BoolVector(List<int> components)
        {
            Components = components;
        }

        public BoolVector(int size)
        {
            Components = new List<int>(size);
        }

        public List<int> Components { get => components; set => components = value; }

        public int getNumberOfZeros()
        {
            List<int> allZeros = Components.FindAll(x => x == 0);
            
            return allZeros.Count;
        }

        public int getNumberOfOne()
        {
            return Components.Count() - getNumberOfZeros();
        }
    }
}
