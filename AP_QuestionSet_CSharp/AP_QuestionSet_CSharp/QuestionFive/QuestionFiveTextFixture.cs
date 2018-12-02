namespace AP_QuestionSet_CSharp.Tests.QuestionFive
{
    using AP_QuestionSet_CSharp.Core.QuestionFive;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class QuestionFiveTextFixture
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
            string sourceDirectory = @"\QuestionFive\Input";
            string destintationDirectory = @"\QuestionFive\Output\";
            string destinationFile = "Poems.txt";

            // Act
            bool success = fileAggregator.Aggregate(Directory.GetCurrentDirectory() + sourceDirectory, Directory.GetCurrentDirectory() + destintationDirectory + destinationFile);

            // Assert
            Assert.IsTrue(success);

        }
    }
}
