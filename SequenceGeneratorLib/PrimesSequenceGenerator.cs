using System;
using System.Collections.Generic;
using System.Text;
using PrimesLib;

namespace SequenceGeneratorLib
{
    public class PrimesSequenceGenerator : ISequenceGenerator
    {
        public double GenerateNthTerm(int n)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n), "Must be > 0"); // only works when n is > 0
            int numPrimes;
            int prime;
            (prime, numPrimes)= Primes.findPrimeByIndex(n);
            return Convert.ToDouble(prime);  

        }

        public double SumOfTerms(int n)
        {
            int[] PrimesArray;
            int TotalNumberOfPrimes;          
            
            if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n), "Must be > 0"); // only works when n is > 0

            (PrimesArray, TotalNumberOfPrimes) = Primes.findPrimeSequence(n); // could also call findPrimeByIndex in loop but much slower
            int SumOfPrimes = 0;
            for (int i = 0; i < PrimesArray.Length; i++)
            {
                SumOfPrimes += PrimesArray[i];
            }
            return Convert.ToDouble(SumOfPrimes);
        }
    }
}
