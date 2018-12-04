namespace AP_QuestionSet_CSharp.Core.QuestionSix
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
            if(string.IsNullOrWhiteSpace(destintationFile)) throw new ArgumentNullException(nameof(destintationFile));

            try
            {
                // 0. Reset destintation outputfile
                fileConsumer.ResetFileAsync(destintationFile);

                // 1. Create Pipe 
                pipe = new BlockingCollection<string>();                                             

                // 2. Create and initalize producers.                
                var files = Directory.GetFiles(sourceDirectory);
                var producers = new List<Task>();
                foreach (var file in files)
                    producers.Add(fileProducer.ProduceFileAsync(file, pipe));
              
                // 3. Create and initalize consumers.                                
                var consumers = new Task[2] {
                    Task.Factory.StartNew(() => fileConsumer.ConsumeFileAsync(destintationFile, pipe)),
                    Task.Factory.StartNew(() => fileConsumer.ConsumeFileAsync(destintationFile, pipe, "consumer 2")) 
                };

                // 4. Await all the consumers, once all files are read, inform the blocking collection of completion.
                Task.Factory.ContinueWhenAll(producers.ToArray(), (p) => pipe.CompleteAdding());

                // 5. Await all consumers to complete writing.
                Task.WaitAll(consumers);
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
