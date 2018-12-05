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

        public static BoolVector conjunction(List<BoolVector> vectors)
        {
            return calculateAction(vectors, new ActionDelegate(elementConjunction));
        }

        public static BoolVector disjunction(List<BoolVector> vectors)
        {
            return calculateAction(vectors, new ActionDelegate(elementDisjunction));
        }

        public static List<BoolVector> negation(List<BoolVector> vectors)
        {
            List<BoolVector> resultVectors = new List<BoolVector>();
            foreach (BoolVector vector in vectors)
            {
                resultVectors.Add(vectorNegation(vector));
            }
            return resultVectors;
        }

        public static BoolVector vectorNegation(BoolVector vector)
        {
            BoolVector resultVector = new BoolVector(vector.Components.Count);
            foreach (int comp in vector.Components)
            {
                resultVector.Components.Add(Convert.ToInt32(comp != 1));
            }
            return resultVector;
        }

        private static BoolVector calculateAction(List<BoolVector> vectors, ActionDelegate action)
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

        private static int elementConjunction(int a, int b)
        {
            return a & b;
        }

        private static int elementDisjunction(int a, int b)
        {
            return a | b;
        }

    }
}
