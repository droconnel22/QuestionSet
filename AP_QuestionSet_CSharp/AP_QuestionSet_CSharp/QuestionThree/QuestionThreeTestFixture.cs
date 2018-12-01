namespace AP_QuestionSet_CSharp.Tests.QuestionThree
{
    using AP_QuestionSet_CSharp.Core.QuestionThree;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class QuestionThreeTestFixture
    {
        [Test]
        public void Convert_JSON_to_Object()
        {
            // Arrange
            const string input = @"{
                                   'Name' : 'Hello',
                                       'This' : {
                                           'That':{
                                               'TheOther' : 'There'
                                            }
                                       }
                                   }";

            const string schema = @"{
                                    'Test_Name': 'Name',
                                    'Test_Value' : 'This.That.TheOther'
                                    }";

            const string expectedJSON = "{\"Test_Name\":\"Hello\",\"Test_Value\":\"There\"}";

            // Act
            string actualJSON = JsonMapper.Map(schema, input);

            // Assert
            Assert.AreEqual(actualJSON, expectedJSON);
        }
    }
}
