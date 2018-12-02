namespace AP_QuestionSet_CSharp.Core.QuestionFive
{
    using System.Threading.Tasks;

    public interface IFileConsumer
    {
        Task ConsumeFileAsync(string fileData, string destinationFile);

        void ResetFileAsync(string destinationFile);
    }
}