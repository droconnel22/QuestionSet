using AP_QuestionSet_CSharp.Core.QuestionOne;
using NUnit.Framework;


namespace AP_QuestionSet_CSharp.Tests.QuestionOne
{

    [TestFixture]
    public class QuestionOneTestFixture
    {

        [Test]
        public void Given_AValidString_AlwaysReturns_TheOriginalInterwovenWithReverse()
        {
            // Arrange
            string input = "ab12";
            const string expected = "a2b11b2a";
            // Act
            string actual = input.ReverseAndInterweave();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_AnotherValidstring_Always_Returns_TheOriginalInterwovenWithReverse()
        {
            // Arrange
            string input = "5t>mKar/Dm!fj/d7";
            const string expectedReverse = "7d/jf!mD/raKm>t5";
            const string expectedReverseInterwoven = "57td>/mjKfa!rm/DD/mr!afKjm/>dt75";

            // Act
            string actualReverse = input.Reverse();
            string actualReverseInterwoven = input.ReverseAndInterweave();

            // Assert
            Assert.AreEqual(expectedReverse, actualReverse);
            Assert.AreEqual(expectedReverseInterwoven, actualReverseInterwoven);
        }
    }
}
