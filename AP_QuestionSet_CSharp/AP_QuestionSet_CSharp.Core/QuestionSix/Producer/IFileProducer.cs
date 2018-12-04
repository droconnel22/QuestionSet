namespace AP_QuestionSet_CSharp.Core.QuestionSix
{
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    public interface IFileProducer
    {
        Task ProduceFileAsync(string inputFile, BlockingCollection<string> pipe);       
    }
}