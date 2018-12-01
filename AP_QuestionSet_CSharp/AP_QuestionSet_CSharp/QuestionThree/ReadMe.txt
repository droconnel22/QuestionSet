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
