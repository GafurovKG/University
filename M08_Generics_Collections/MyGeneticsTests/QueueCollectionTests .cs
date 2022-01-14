using MyGenetics;
using NUnit.Framework;

namespace MyGeneticsTests
{
    [TestFixture]
    public class QueueCollectionTests
    {
        [Test]
        public void Dequeue_removeTopElement_()
        {
            string firstElement = "first";
            string secondElement = "second";
            string thirdElement = "third";
            var queueCollection = new QueueCollection<string>();
            queueCollection.Enqueue(firstElement);
            queueCollection.Enqueue(secondElement);
            queueCollection.Enqueue(thirdElement);
            Assert.That(queueCollection.Dequeue().Equals(firstElement) && queueCollection.Count.Equals(2));
        }
    }
}