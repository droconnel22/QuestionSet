namespace AP_QuestionSet_CSharp.Core.QuestionFive
{
    using System;    
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class FileProducer : IFileProducer
    {       
        public async Task<string> ProduceFileAsync(string inputFile)
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
                return fileText;
            }
            catch (AggregateException exception)
            {
                Console.WriteLine($"Failed to complete reading the file {inputFile} due to exception: {exception.Message} at {exception.StackTrace}");
                return string.Empty;
            }
        }    
    }    
}
