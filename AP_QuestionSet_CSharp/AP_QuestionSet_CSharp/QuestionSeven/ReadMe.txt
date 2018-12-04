(multi-threading)
Write a class that holds an internal ICollection<string, object> object and exposes 
the ability to 

add, update, delete entries in the dictionary 

in a thread-safe manner.

Thoughts: 

The approach here was for me to demonstrate the Parallel programming available in .NET. One that is not task based, but still takes
advantage of the Task Parallel Library. The Parallel forEach loop is ideal for writing concentrated tests for a concurrent collection
tests. Parallel for each run each iteration in parallel, easily exposing any flaws in an objected charged with managing a shared resource.
Some additional methods where added to the interface for testing, such has getValue and count. This ensures that the asserts are useful. It 
also provides an opportunity to demonstrate the trivial lock approach, and the more careful try/finally with monitoring. Both are doing the 
same thing, but Monitoring peels back a little bit of the curtain and shows that parallel programming can become scary very quickly.

Another demonstration where was the use of Generics. Include the use of where limitied the types that can be used, the default() which is 
something that should be in generic code more, this defaults the type, so references are generally null and something like int would be int.min.
Generics in .NET shine more then other languages, where Java they can be more restrictive, in .NET they can shine.

Finally the handler approach. It was known from the initial design approach that each major function defined in the requirements would need
resource management. .NET has great functor support and in the spirit of not repeating the same infrastructure code over and over again, I 
created a private handler method that took in the key, value, and the method to be performed. This handler completely owns the monitoring and 
error handling, produces very clean and simple method implemetnation for the other properties, in fact all the major operations: add, update, and
delete are one liner functions, because of avoiding unecessary boilerplate coding more then once. The handler is brittle in the sense of return types
in that way another handler might be jusitifed for returning a boolean or value itself. 
