namespace AP_QuestionSet_CSharp.Core.QuestionFive
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFileProducer
    {
        Task<string> ProduceFileAsync(string inputFile);       
    }
}