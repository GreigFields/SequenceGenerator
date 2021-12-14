using System;

namespace SequenceGeneratorLib
{
    public class FibonacciSequenceGenerator : ISequenceGenerator
    {
        public double GenerateNthTerm(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n), "Must be >= 0");
            if (n == 0) return 0;
            if (n == 1) return 1;

            return GenerateNthTerm(n - 1) + GenerateNthTerm(n - 2);
        }

        public double SumOfTerms(int n)
        {
            var result = 0.0;
            for (var i = 1; i <= n; ++i)
            {
                result += GenerateNthTerm(i);
            }

            return result;
        }
    }
}
