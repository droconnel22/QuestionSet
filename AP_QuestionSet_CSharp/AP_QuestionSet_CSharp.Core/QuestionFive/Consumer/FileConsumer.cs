namespace AP_QuestionSet_CSharp.Core.QuestionFive
{
    using System;    
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public class FileConsumer : IFileConsumer
    {
        public async Task ConsumeFileAsync(string fileData, string destinationFile)
        {
            try
            {
                Console.WriteLine($"Writing file {fileData.Substring(0,25)} to output");                
                byte[] encodedText = Encoding.Unicode.GetBytes(fileData + Environment.NewLine + Environment.NewLine);
                using (FileStream sourceStream = new FileStream(destinationFile,
                    FileMode.Append, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true))
                {
                    await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                };

            }
            catch (AggregateException exception)
            {
                Console.WriteLine($"Failed to write to file {destinationFile} because {exception.Message}");
                if(exception.InnerExceptions.Any())
                {
                    foreach (var innerex in exception.InnerExceptions)
                    {
                        Console.WriteLine($" failed because {innerex.Message} ");
                    }                   
                }
            }           
        }

        public void ResetFileAsync(string destinationFile)
        {
            if (File.Exists(destinationFile))
            {
                File.Delete(destinationFile);
            }
        }
    }
}
