namespace AP_QuestionSet_CSharp.Core.QuestionSix
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading.Tasks;

    public class FileProducer : IFileProducer
    {       
        public async Task ProduceFileAsync(string inputFile, BlockingCollection<string> pipe)
        {
            
            if (string.IsNullOrEmpty(inputFile))
                throw new ArgumentNullException(nameof(inputFile));

            string fileText = string.Empty;
            Console.WriteLine($"Reading the file ... {inputFile}");
            try
            {
                using (var reader = File.OpenText(inputFile))
                {
                    fileText += await reader.ReadToEndAsync();                   
                }                

                Console.WriteLine($"Completed Reading File: {inputFile}");
                pipe.Add(fileText);
            }
            catch (AggregateException exception)
            {
                Console.WriteLine($"Failed to complete reading the file {inputFile} due to exception: {exception.Message} at {exception.StackTrace}");                
            }
        }    
    }    
}
