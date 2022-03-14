using System;
namespace SequenceGeneratorLib
{
    //The Liebniz sequence is defined as follows:
    //
    //T(0) = 1
    //T(n where n > 0) =
    //  -1 / (2n + 1) when n is odd
    //   1 / (2n + 1) when n is even

    //Implement this sequence generator based on the ISequenceGenerator interface
    // This value yould approach Pi/4
    public class LiebnizSequenceGenerator : ISequenceGenerator
    {
        public double GenerateNthTerm(int n) 
        {
            if (n <  0) throw new ArgumentOutOfRangeException(nameof(n), "Must be > 0"); // only works when n is > 0
            if ((n%2) == 0) // If n is even then numerator is 1 
            {
                return (1.0 / ((2.0 * n) + 1.0)); 
            }

            return (n==0?1.0:-1.0 / ((2.0 * n) + 1.0)); // n is odd so then numerator is -1 - Check for n==0 if so return 1
        }

        public double SumOfTerms(int n)
        {
            double d = 0; ;
            if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n), "Must be > 0");
            for (int i =0; i< n;i++) // Start with first legal value for n and include all values from there including n
            {
                d += GenerateNthTerm(i);
            }
            return d;
        }
        public double[] ListOfTerms(int n) // Return a list of the Terms to check that sequence is followed correctly
        {

            double[] terms = new double[n];
            for (var i = 1; i <= n; ++i)
            {
                terms[i - 1] = GenerateNthTerm(i);
            }

            return terms;
        }
    }
}
