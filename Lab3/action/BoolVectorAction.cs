using Lab3.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.action
{
    public class BoolVectorAction
    {
        delegate int ActionDelegate(int a, int b);

        public static BoolVector Conjunction(List<BoolVector> vectors)
        {
            return CalculateAction(vectors, new ActionDelegate(ElementConjunction));
        }

        public static BoolVector Disjunction(List<BoolVector> vectors)
        {
            return CalculateAction(vectors, new ActionDelegate(ElementDisjunction));
        }

        public static List<BoolVector> Negation(List<BoolVector> vectors)
        {
            List<BoolVector> resultVectors = new List<BoolVector>();
            foreach (BoolVector vector in vectors)
            {
                resultVectors.Add(VectorNegation(vector));
            }
            return resultVectors;
        }

        public static BoolVector VectorNegation(BoolVector vector)
        {
            BoolVector resultVector = new BoolVector(vector.Components.Count);
            foreach (int comp in vector.Components)
            {
                resultVector.Components.Add(Convert.ToInt32(comp != 1));
            }
            return resultVector;
        }

        private static BoolVector CalculateAction(List<BoolVector> vectors, ActionDelegate action)
        {
            int size = vectors[0].Components.Count;
            foreach (BoolVector vector in vectors)
            {
                if (vector.Components.Count != size)
                {
                    throw new ArgumentException("All bool vectors must be the same size");
                }
            }
            BoolVector resultVector = vectors[0];
            for (int i = 0; i < size; i++)
            {
                foreach (BoolVector vector in vectors)
                {
                    resultVector.Components[i] = action(resultVector.Components[i], vector.Components[i]);

                }
            }
            return resultVector;
        }

        private static int ElementConjunction(int a, int b)
        {
            return a & b;
        }

        private static int ElementDisjunction(int a, int b)
        {
            return a | b;
        }

    }
}
