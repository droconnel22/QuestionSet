namespace AP_QuestionSet_CSharp.Core.QuestionSix
{
    using System;    
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;

    public class FileConsumer : IFileConsumer
    {
        public async Task ConsumeFileAsync(string destinationFile, BlockingCollection<string> pipe, string consumerName = "consumer 1")
        {
            try
            {
                while (!pipe.IsCompleted)
                {
                    string fileData;
                    if (pipe.TryTake(out fileData))
                    {
                        Console.WriteLine($"Writing file {fileData.Substring(0, 25)} to output");
                        byte[] encodedText = Encoding.Unicode.GetBytes(fileData + Environment.NewLine + Environment.NewLine);
                        using (FileStream sourceStream = new FileStream(destinationFile,
                            FileMode.Append, FileAccess.Write, FileShare.None,
                            bufferSize: 4096, useAsync: true))
                        {
                            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                        };

                        
                    }                   
                }

                Console.WriteLine($"{consumerName} has completed.");

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
