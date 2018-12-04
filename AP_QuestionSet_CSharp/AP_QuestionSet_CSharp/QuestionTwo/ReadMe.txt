Question 2:

Write a function to check a string to see if it is a palindrome. Spaces should be ignored. For example:

Sample Text
Result
taco cat
true
some men interpret nine memos
true
never odd or even
true
This is not a palindrome
false
1 test for numerics
false
289982
true
1234321
true


Thoughts: Originally thought a stack would be required, but turns out that the replacing the 
white spaces simplified the design requirements. Palindromes are tricky because the odd element
will have no counterpart, but still qualify as a palindrome. 

The implementation compares the polar opposite as the same time, should at any point this requirement fail
the solution would immediately exit without the cost of evaluating all of N.