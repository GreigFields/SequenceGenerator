using SequenceGeneratorLib;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequenceGenerator = new LiebnizSequenceGenerator();
            var tenthTerm = sequenceGenerator.GenerateNthTerm(10);
            var sumOfTenTerms = sequenceGenerator.SumOfTerms(10);

            Console.WriteLine($"Sequence generator: {sequenceGenerator.GetType().Name}");
            Console.WriteLine($"10th term: {tenthTerm}");
            Console.WriteLine($"Sum of 10 terms: {sumOfTenTerms}");


            Console.ReadKey();
        }
    }
}

