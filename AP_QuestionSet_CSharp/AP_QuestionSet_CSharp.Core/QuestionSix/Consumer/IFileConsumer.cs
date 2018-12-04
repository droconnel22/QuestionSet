namespace AP_QuestionSet_CSharp.Core.QuestionSix
{
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    public interface IFileConsumer
    {
        Task ConsumeFileAsync(string destinationFile, BlockingCollection<string> pipe, string consumerName="consumer 1");

        void ResetFileAsync(string destinationFile);
    }
}