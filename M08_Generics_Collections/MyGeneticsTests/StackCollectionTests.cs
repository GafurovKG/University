using MyGenetics;
using NUnit.Framework;

namespace MyGeneticsTests
{
    [TestFixture]
    public class StackCollectionTests
    {
        [Test]
        public void Dequeue_removeTopElement_()
        {
            string firstElement = "first";
            string secondElement = "second";
            string thirdElement = "third";
            var stackCollection = new StackCollection<string>();
            stackCollection.Enqueue(firstElement);
            stackCollection.Enqueue(secondElement);
            stackCollection.Enqueue(thirdElement);
            Assert.That(stackCollection.Dequeue().Equals(thirdElement) && stackCollection.Count.Equals(2));
        }
    }
}