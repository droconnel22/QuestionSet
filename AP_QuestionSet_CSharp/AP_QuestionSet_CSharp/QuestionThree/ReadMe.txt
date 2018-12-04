Write a mapping function that takes in a string of json payload and another
string of mappings and returns a string of the mapped data. For example a payload of:
{
"Name" : "Hello",
"This" : {
"That" : {
“TheOther” : "There"
}
}
}
And a map of:
{
"Test_Name" : "Name",
"Test_Value" : "This.That.TheOther"
}
Should return:
{
"Test_Name" : "Hello",
"Test_Value" : "There"
}


Thoughts:

This was a difficult problem for .NET. You have a vendor software in JSON.NET and the object rigidity of .NET itself that makes traversing object
graphs very cubersome, when compared to Python or Javascript. 

Here I used the unusual Dynamic type paradigm, for the model being passed in. This allows traversal of the JSON without requiring a concrete type
to be created and annotated. The assumption here is that the schema JSON is always flat, meaing only one level, so the key definitions is straight
forward, the travesl through the dynamic graph requires a light depth first search approach. The code will keep traversing the dynamic object graph
until either the path is missing or reaches completion. The resulting object is also flat, meaning there is no nesting, so a simplistic dictionary 
would do then leveraging the vendor library to actually generate the Json. For the purposes of passing tests I omitted the new lines, end of lines
and spaces. In production environment the vendor result would be passed back to the response body or message body itself with no further formatting
as is done.

