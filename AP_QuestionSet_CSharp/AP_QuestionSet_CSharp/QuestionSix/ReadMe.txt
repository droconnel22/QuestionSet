(multi-threading)
Write a function that takes a folder of files and an output file location as inputs and 
opens all the files in the folder (using Parallelization technique of your choosing) and 
writes all of the text in the files into the single file ensuring all data is written.


Thoughts: I choose the more difficult of the two multithreading problems, and depending if I have time I will try the other.
A lot has happened in the last 10 years with regards to the way .NET approaches paralalization. In this fashion I went with the
latest paradigm of Async/Await over the traditional threading libraries. While having more overhead with similar performance,
the Task based approached is generally a safer way to utitlize resources more effectively and not get into trouble with potential
deadlock on shared resources, premature thread closing, hidden exceptions, processor/thread management, and other common pitfuls in 
multithreading programming.

I implemented a Producer-Consumer model, using the highly recommended Blocking Collection data structure produced
by Microsoft. A task is created for each file for the File Producer. Once the file is read asynchronously, it is added to the blocking
collection. The Consumer is listening for any items added to the blocking collection and if one exist will pop it off the collection and
asynchronously write it to a new our existing output file. Once the last item has been processsed the blocking collection shines as the API
allows the Producer to inform the collection that it is completed with its inputs. The collection is smart enough to wait until there
are no more items and then it breaks out of the loop.

Performance is stable, the implementation is modern, and more importantly steps are taken to ensure there are as few low 
level risks as possible. Leveraging using statement is best practice for scope and file ownership management. Using clauses
would help prevent contention in the case of multiple consumers.

Testing is a bit difficult as either a greater then necessary mocking effort is done, or the code completes without error and the 
output file is inspected.

*Be sure to check if all the Input/ and Output/ Files are set to (f4 in VS) copy if newer. Please take any liberties while 
testing to change the underlying directory paths. It should work as written with no intervention required, but in my experience
directories can change between machines.

*Update: I originally had one consumer, but after considering the advantages of the the blocking collection it was little
cost to update the consumer to a collection of tasks, the cost is some code repeation, but the power of the Producer-Consumer
paradigm is elevated with multiple agents.

*Update 2: I decided to refactor in the Blocking Collection into the Producer and Consumer method signatures. The idea being here to
clean up the code base and eliminating having to wrap a task over another task. An improvment was also made with continueWith as a cleaner
way to inform the Blocking Collection is done adding items. Refactoring the task method signatures for the consumers also removes the previously
repeated code, and correctly resuses the code base. Having two consumers is important to demonstrate that the async file writing stream natively
takes care of managing a shared resource, in this the output file. Demonstartion of optional parameters was also done.


FYI:
https://docs.microsoft.com/en-us/dotnet/standard/io/asynchronous-file-i-o
Starting with the .NET Framework 4.5, the I/O types include async methods to simplify asynchronous operations
. An async method contains Async in its name, such as ReadAsync, WriteAsync, CopyToAsync, FlushAsync, ReadLineAsync, 
and ReadToEndAsync. These async methods are implemented on stream classes, such as Stream, FileStream, and MemoryStream,
and on classes that are used for reading from or writing to streams, such TextReader and TextWriter.


https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.blockingcollection-1?redirectedfrom=MSDN&view=netframework-4.7.2

