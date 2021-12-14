namespace SequenceGeneratorLib
{
    public interface ISequenceGenerator
    {
        double GenerateNthTerm(int n);
        double SumOfTerms(int n);
    }
}
