using SequenceGeneratorLib;
using Xunit;

namespace TestProject
{
    public class FibonacciSequenceGeneratorTests
    {
        [Fact]
        public void Term0ShouldBe0()
        {
            var sut = new FibonacciSequenceGenerator();
            Assert.Equal(0.0, sut.GenerateNthTerm(0));
        }

        [Fact]
        public void Term1ShouldBe1()
        {
            var sut = new FibonacciSequenceGenerator();
            Assert.Equal(1.0, sut.GenerateNthTerm(1));
        }

        [Fact]
        public void FirstTenTermsShouldBeAccurate()
        {
            var sut = new FibonacciSequenceGenerator();
            var previousTerm = 1.0;
            var expected = 1.0;
            for (var i = 2; i <= 10; ++i)
            {
                var newTerm = sut.GenerateNthTerm(i);
                Assert.Equal(expected, newTerm, 4);

                expected = previousTerm + newTerm;
                previousTerm = newTerm;
            }

        }
    }
}
