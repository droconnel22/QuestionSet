using AP_QuestionSet_CSharp.Core.QuestionTwo;
using NUnit.Framework;


namespace AP_QuestionSet_CSharp.Tests.QuestionTwo
{
    [TestFixture]
    public class QuestionTwoTestFixture
    {

        [TestCase("taco cat", true)]
        [TestCase("some men interpret nine memos", true)]
        [TestCase("never odd or even", true)]
        [TestCase("This is not a palindrom", false)]
        [TestCase("1 test for numerics", false)]
        [TestCase("289982", true)]
        [TestCase("1234321", true)]
        public void IsPalindromeTest(string input, bool expected) => 
            Assert.AreEqual(Palindrome.Check(input), expected);
    }
}
