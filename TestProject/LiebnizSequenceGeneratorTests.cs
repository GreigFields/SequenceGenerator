using SequenceGeneratorLib;
using Xunit;
using System;
//return (-1 / ((2 * n) + 1)); // n is odd so then numerator is -1
namespace TestProject
{
    public class LiebnizSequenceGeneratorTests
    {
        [Fact]
        public void TermLessThan0ShouldBeFalut()
        {
            var lsg = new LiebnizSequenceGenerator();
            try
            {
                double d = lsg.GenerateNthTerm(-1);
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
        public void Term0ShouldBe1()
        {
            var sut = new LiebnizSequenceGenerator();
            Assert.Equal(1.0, sut.GenerateNthTerm(0));
        }

        [Fact]
        public void Term1ShouldBe1Third()
        {
            var sut = new LiebnizSequenceGenerator();
            Assert.Equal(-1.0/3.0, sut.GenerateNthTerm(1));
        }
        [Fact]
        public void Term10ShouldBe1dividedby21()
        {
            var lsg = new LiebnizSequenceGenerator();
            Assert.Equal(1.0 / 21.0, lsg.GenerateNthTerm(10));
        }

        [Fact]
        public void CheckSumOfFirstTenTerms()
        {
            var lsg = new LiebnizSequenceGenerator();
            double actual = 0;
            double expected = lsg.SumOfTerms(10); // got to find this number...
            for (var i = 0; i < 10; ++i)
            {
                actual += lsg.GenerateNthTerm(i);
            }
            Assert.Equal(expected, actual); // Check if the results of manually adding sequence values and calling SumOfTerms
        }
        [Fact]
        public void CheckValueOfFifthTerm()
        {
            var lsg = new LiebnizSequenceGenerator();
            Assert.Equal(Convert.ToDouble(1)/Convert.ToDouble(9), lsg.GenerateNthTerm(4)); // Check if the results of manually adding sequence values and calling SumOfTerms
        }
    }
}
