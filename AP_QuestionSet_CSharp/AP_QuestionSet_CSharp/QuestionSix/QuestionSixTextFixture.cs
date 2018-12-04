namespace AP_QuestionSet_CSharp.Tests.QuestionSix
{
    using AP_QuestionSet_CSharp.Core.QuestionSix;
    using NUnit.Framework;
    using System.IO;
    

    [TestFixture]
    public class QuestionSixTestFixture
    {
        private FileAggregator fileAggregator;
        private IFileConsumer fileConsumer;
        private IFileProducer fileProducer;


        [SetUp]
        public void Setup()
        {
            fileConsumer = new FileConsumer();
            fileProducer = new FileProducer();

            fileAggregator = new FileAggregator(fileConsumer, fileProducer);
        }           


        [Test]
        public void RunScenarioAsync()
        {
            // Arrange
            string sourceDirectory = @"\QuestionSix\Input";
            string destintationDirectory = @"\QuestionSix\Output\";
            string destinationFile = "Poems.txt";

            // Act
            bool success = fileAggregator.Aggregate(Directory.GetCurrentDirectory() + sourceDirectory, Directory.GetCurrentDirectory() + destintationDirectory + destinationFile);

            // Assert
            Assert.IsTrue(success);

        }
    }
}
