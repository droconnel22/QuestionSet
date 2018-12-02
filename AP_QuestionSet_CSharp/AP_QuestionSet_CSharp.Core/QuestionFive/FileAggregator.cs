namespace AP_QuestionSet_CSharp.Core.QuestionFive
{
    using System;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public class FileAggregator
    {

        private BlockingCollection<string> pipe;

        private readonly IFileConsumer fileConsumer;

        private readonly IFileProducer fileProducer;

        public FileAggregator(IFileConsumer fileConsumer, IFileProducer fileProducer)
        {
            this.fileConsumer = fileConsumer;
            this.fileProducer = fileProducer;
        }

        
        public bool Aggregate(string sourceDirectory, string destintationFile)
        {
            if(string.IsNullOrWhiteSpace(sourceDirectory)) throw new ArgumentNullException(nameof(sourceDirectory));
            if (string.IsNullOrWhiteSpace(destintationFile)) throw new ArgumentNullException(nameof(destintationFile));

            try
            {
                // 0. Reset destintation outputfile
                fileConsumer.ResetFileAsync(destintationFile);

                // 1. Create Pipe 
                pipe = new BlockingCollection<string>();                                             

                // 2. Create and initalize producers.
                var tasks = new List<Task>();
                var files = Directory.GetFiles(sourceDirectory);
                foreach (var file in files)
                    tasks.Add(Task.Factory.StartNew(async () =>
                    {
                        var fileData = await fileProducer.ProduceFileAsync(file);
                        pipe.Add(fileData);
                        if(file == files.Last())
                        {
                           pipe.CompleteAdding();
                        }
                    }));

                // 3. Create and initalize consumer.
                var consumer = Task.Factory.StartNew(async () =>
                {
                    while (!pipe.IsCompleted)
                    {
                        string fileData;
                        if (pipe.TryTake(out fileData))
                            await fileConsumer.ConsumeFileAsync(fileData, destintationFile);
                    }
                    Console.WriteLine("Consumer all done!");
                });

                Task.WaitAll(tasks.ToArray());                
                consumer.Wait();
                return true;
            }
            catch (AggregateException exception)
            {
                Console.WriteLine($"Failed to read files because {exception.Message}");
                return false;
            }            
        }      
    }    
}
