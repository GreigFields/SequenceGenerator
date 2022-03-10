using SequenceGeneratorLib;
using Xunit;
using System;

namespace TestProject
{
    public class PrimesSequenceGeneratorTests
    {
        [Fact]
        public void Term0ShouldFail() // Term Zero should Fail
        {
            var psg = new PrimesSequenceGenerator();
            try
            {
                double d = psg.GenerateNthTerm(0);
                Assert.True(false); // Fail Test if zero n value succeds to return a value.
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.True(true); // Test succeeded if ArgumentOutOfRangeException thrown.
            }
            catch
            {
                Assert.True(false); // Fail test if Exception is not ArgumentOutOfRangeException
            }
        }

        [Fact]
        public void Prime1ShouldBe2()  // !st prime is 2
        {
            var psg = new PrimesSequenceGenerator();
            Assert.Equal(2, psg.GenerateNthTerm(1));
        }
        [Fact]
        public void Prime10ShouldBe29()  // check that prime 10 works
        {
            var psg = new PrimesSequenceGenerator();
            Assert.Equal(29, psg.GenerateNthTerm(10));
        }

        [Fact]
        public void CheckSumOfFirstTenTermsManual() // Do this going through calling each by index and summing
        {
            var psg = new PrimesSequenceGenerator();
            double actual = 0;
            double expected = psg.SumOfTerms(10); // got to find this number...
            for (var i = 0; i < 10; ++i)
            {
                actual += psg.GenerateNthTerm(i+1);  // Long way of doing it but it's only a test
            }
            Assert.Equal(expected, actual); // Check if the results of manually adding sequence values and calling SumOfTerms
        }
        [Fact]
        public void CheckSumOfFirstTenTerms() // Use the PrimesLibary SumOfTerms call
        {
            var psg = new PrimesSequenceGenerator();
            double expected = 2+3+5+7+11+13+17+19+23+29;
            double actual = psg.SumOfTerms(10); // 

            Assert.Equal(expected, actual); // Check if the results of manually adding sequence values and calling SumOfTerms
        }
    }
}

