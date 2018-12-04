namespace AP_QuestionSet_CSharp.Tests.QuestionSeven
{
    using AP_QuestionSet_CSharp.Core.QuestionSeven;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestFixture]
    public class QuestionSevenTestFixture
    {
        private class MyFooClass { }

        private ConcurrentDictionary<string,object> concurrentDictionary;

        [SetUp]
        public void SetUp()
        {
            concurrentDictionary = new ConcurrentDictionary<string, object>();
        }

        [Test]
        public void Add_Given_Two_Identicalkeys_Always_ReturnsCountOfOne()
        {
            // Arrange
            var additions = new List<string>() { "Skunk", "Skunk" };

            // Act

            Parallel.ForEach(additions, ts =>
            {
                concurrentDictionary.Add(ts, new object());
            });


            // Assert
            Assert.AreEqual(1, concurrentDictionary.Count());
        }

        [Test]
        public void Add_Given_Two_DifferentKeys_Always_ReturnsCountOfTwo()
        {
            // Arrange
            var additions = new List<string>() { "Skunk", "Bear" };

            // Act

            Parallel.ForEach(additions, ts =>
            {
                concurrentDictionary.Add(ts, new object());
            });


            // Assert
            Assert.AreEqual(2, concurrentDictionary.Count());
        }

        [Test]
        public void Update_Given_AnExistingItem_Always_Updates()
        {
            // Arrange
            var additions = new List<string>() { "Skunk", "Skunk" };
            var updates = new List<Tuple<string, object>>()
            {
                Tuple.Create<string,object>("Skunk", new MyFooClass())
            };

            // Act

            Parallel.ForEach(additions, ts =>
            {
                concurrentDictionary.Add(ts, new object());
            });

            Parallel.ForEach(updates, ts =>
            {
                concurrentDictionary.Update(ts.Item1, ts.Item2);
            });


            // Assert
            Assert.AreEqual(1, concurrentDictionary.Count());
            Assert.AreEqual(concurrentDictionary.GetValue("Skunk").GetType(), typeof(MyFooClass));
        }

        [Test]
        public void Update_Given_TwoExistingItem_Always_Updates()
        {
            // Arrange
            var additions = new List<string>() { "Skunk", "Skunk", "Bear", "Bear" };
            var updates = new List<Tuple<string, object>>()
            {
                Tuple.Create<string,object>("Skunk", new MyFooClass()),
                Tuple.Create<string,object>("Bear", new MyFooClass())
            };

            // Act

            Parallel.ForEach(additions, ts =>
            {
                concurrentDictionary.Add(ts, new object());
            });

            Parallel.ForEach(updates, ts =>
            {
                concurrentDictionary.Update(ts.Item1, ts.Item2);
            });


            // Assert
            Assert.AreEqual(2, concurrentDictionary.Count());
            Assert.AreEqual(concurrentDictionary.GetValue("Skunk").GetType(), typeof(MyFooClass));
            Assert.AreEqual(concurrentDictionary.GetValue("Bear").GetType(), typeof(MyFooClass));
        }

        [Test]
        public void Update_Given_Empty_Never_Throws()
        {
            // Arrange
            var additions = new List<string>();
            var updates = new List<Tuple<string, object>>()
            {
                Tuple.Create<string,object>("Skunk", new MyFooClass())
            };

            // Act

            Parallel.ForEach(additions, ts =>
            {
                concurrentDictionary.Add(ts, new object());
            });

            Parallel.ForEach(updates, ts =>
            {
                concurrentDictionary.Update(ts.Item1, ts.Item2);
            });


            // Assert
            Assert.AreEqual(0, concurrentDictionary.Count());
            
         }

        [Test]
        public void Delete_Given_PopulatedCollection_AlwaysDeletes()
        {
            // Arrange
            var additions = new List<string>() { "Skunk", "Skunk", "Bear", "Bear" };
            var deletions = new List<string>() { "Skunk", "Skunk", "Bear", "Bear" };

            // Act

            Parallel.ForEach(additions, ts =>
            {
                concurrentDictionary.Add(ts, new object());
            });

            Parallel.ForEach(deletions, ts =>
            {
                concurrentDictionary.Delete(ts);
            });


            // Assert
            Assert.AreEqual(0, concurrentDictionary.Count());

        }

    }

   
}
