namespace AP_QuestionSet_CSharp.Tests.QuestionThree
{
    using AP_QuestionSet_CSharp.Core.QuestionThree;    
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

        [Test]
        public void Convert_JSON_to_Object_Attack_On_Upatu()
        {
            // Arrange
            const string input = @"{
                                   'beets' : 'General',
                                   'meets' : 'Kenobi',
                                   'Your': {
                                           'A' : {
                                                'Bold': 'One'
                                            },
                                            'He': {
                                                    'Is': {
                                                          'Here': {
                                                                'We':'Are Under Attack'
                                                           }
                                                    }
                                            }
                                    }
                                  }";

            const string schema = @"{
                                    'Test_Rank': 'beets',
                                    'Test_Jedi': 'meets',
                                    'Grevious': 'Your.A.Bold',
                                    'Send In the Clones':'Your.He.Is.Here.We'
                                    }";

           const string expectedJSON = "{\"Test_Rank\":\"General\",\"Test_Jedi\":\"Kenobi\",\"Grevious\":\"One\",\"SendIntheClones\":\"AreUnderAttack\"}";

            // Act
            string actualJSON = JsonMapper.Map(schema, input);

            // Assert
            Assert.AreEqual(actualJSON, expectedJSON);
        }
    }
}
