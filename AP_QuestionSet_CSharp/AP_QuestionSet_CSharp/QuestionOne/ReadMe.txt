Write a function to take in a string and return a string that is itself with the reverse of it interwoven together. 

For example, "ab12" would be"ab12" and "21ba" interwoven to make: "a2b11b2a"


Some thoughts:

Strings are not primitave but reference types. In addition to having the inherited qualties of an object they are also
Enumerable. 

I wanted to purposefully avoid Linq and focus more on Enumerators which are powerful and safe objects
that are purpose built for  conditionally enumerating through collections. The Enumerator pattern itself is in some cases
a better practice then exposing indexes. 

That being said, enumerators are not as ideal for certain array operations. In the custom Reverse function, I made an example of where
indexes themselves are superior to enumerators, though greater care must be taken.

On implementation I chose extension methods. This version of the decorator pattern, specific only to .NET as Java does not allow extensions or
decoration of objects, Python, and Javascript have no concept of encapsulation and therefore have no need for a mechanism to expose the
object pointer.

Extensions methods here do not mutate the calling object, and really can't because strings are immutable of themselves, rather they provide
a cleaner and simplier way then creating an entire class for a simple function. C#/.NET also does not allow functions to be first class, which 
given the trival requirement would have been ideal, over a single strategy class. Extensions can bridge that gap in the language.

Thoughts on performance. The reverse algorithim does an in place swap, similar to quicksort, and is perforamnt for space requirments only
requiring for space O(N+1) (would drop non dominate terms for O(N)). For time complexity, the algorithm swaps the polar opposite elements requiring only half of the array to be 
traversed, leading to an O(N/2). 

Since the interwoven condition is depended on indexing order and not weight or lexigraphical considerations, doing a merge sort approach
which is more stable and has superior run time with an increased space cost would be overly complex for the requirements given.
