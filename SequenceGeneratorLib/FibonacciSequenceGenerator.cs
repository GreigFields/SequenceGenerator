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

            return GenerateNthTerm(n - 1) + GenerateNthTerm(n - 2); // Nice recursion but uses too much time pushing and popping the stack
        }
        public long GenerateNthTermLong(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n), "Must be >= 0");
            if (n == 0) return 0;
            if (n == 1) return 1;

            return GenerateNthTermLong(n - 1) + GenerateNthTermLong(n - 2); // Nice recursion but uses too much time pushing and popping the stack
        }
        public double GenerateNthTermFor(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n), "Must be >= 0");
            if (n == 0) return 0;
            if (n == 1) return 1;
            double prev = 1;
            double curr = 1;
            for(int i = 2; i < n; i++) // Much faster to use a straight for loop
            {
                double hold = curr;
                curr = prev + curr;
                prev = hold;
            }
            return curr;
        }
        public double GenerateNthTermForLong(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n), "Must be >= 0");
            if (n == 0) return 0;
            if (n == 1) return 1;
            long prev = 1;
            long curr = 1;
            for (int i = 2; i < n; i++) // Even faster to use a straight for loop and Long versus double
            {
                long hold = curr;
                curr = prev + curr;
                prev = hold;
            }
            return Convert.ToDouble(curr);
        }
        public double SumOfTermsLong(int n)
        {
            long result = 0;
            for (var i = 1; i <= n; ++i)
            {
                result += GenerateNthTermLong(i);
            }

            return result;
        }
        public double SumOfTermsFor(int n)
        {
            var result = 0.0;
            for (var i = 1; i <= n; ++i)
            {
                result += GenerateNthTermFor(i);
            }

            return result;
        }
        public double SumOfTermsForLong(int n)
        {
            var result = 0.0;
            for (var i = 1; i <= n; ++i)
            {
                result += GenerateNthTermForLong(i);
            }

            return result;
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
        public long[] ListOfTerms(int n)
        {
            long[] terms = new long[n];
            for (var i = 1; i <= n; ++i)
            {
                terms[i-1] = Convert.ToInt64(GenerateNthTerm(i));
            }

            return terms;
        }
        public long[] ListOfTermsFor(int n)
        {
            long[] terms = new long[n];
            for (var i = 1; i <= n; ++i)
            {
                terms[i - 1] = Convert.ToInt64(GenerateNthTermFor(i));
            }

            return terms;
        }
        public long[] ListOfTermsForLong(int n)
        {
            long[] terms = new long[n];
            for (var i = 1; i <= n; ++i)
            {
                terms[i - 1] = Convert.ToInt64(GenerateNthTermForLong(i));
            }

            return terms;
        }
    }
}
