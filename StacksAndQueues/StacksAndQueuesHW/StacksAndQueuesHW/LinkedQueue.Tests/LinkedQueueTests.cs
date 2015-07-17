using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS.Implementations;

namespace LinkedQueue.Tests
{
    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Peek on empty queue should throw InvalidOperationException")]
        public void PeekOnEmptyStackShouldThrowException()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Pop on empty queue should throw InvalidOperationException")]
        public void PopOnEmptyStackShouldThrowException()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void PushPopShouldSetCountCorrectlyAndReturnCorrectElement()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            Assert.AreEqual(0, queue.Count, "Count for newly created queue is not correct.");
            queue.Enqueue(3);
            Assert.AreEqual(1, queue.Count, "Count for a single pushed element is not correct.");
            Assert.AreEqual(3, queue.Dequeue(), "Popped element is not correct.");
            Assert.AreEqual(0, queue.Count, "Count for single pushed and popped element is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Pop on empty queue should throw InvalidOperationException")]
        public void PushPopManyElementsShouldSetCountCorrectlyAndReturnCorrectElement()
        {
            LinkedQueue<string> queue = new LinkedQueue<string>();

            Assert.AreEqual(0, queue.Count, "Count for newly created queue is not correct.");

            for (int i = 0; i < 1000; i++)
            {
                queue.Enqueue(i.ToString());
                Assert.AreEqual(i + 1, queue.Count, string.Format("Count is not correct for element {0}", i));
            }

            for (int i = 1000; i >= 0; i--)
            {
                Assert.AreEqual((1000-i ).ToString(), queue.Dequeue(), "Popped element is not correct.");
                Assert.AreEqual(i - 1, queue.Count, "Count after element popping is not correct");
            }
        }

        [TestMethod]
        public void PushPeekManyElementsShouldSetCountCorrectlyAndReturnCorrectElement()
        {
            LinkedQueue<string> queue = new LinkedQueue<string>();

            Assert.AreEqual(0, queue.Count, "Count for newly created queue is not correct.");

            for (int i = 0; i < 1000; i++)
            {
                queue.Enqueue(i.ToString());
            }

            for (int i = 1000; i >= 0; i--)
            {
                Assert.AreEqual("0", queue.Peek(), "Peeked element is not correct.");
                Assert.AreEqual(1000, queue.Count, "Count after element peeking is not correct");
            }
        }

        [TestMethod]
        public void PushPopFromStackWithInitialCapacity1ShouldWorkCorrectly()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            Assert.AreEqual(0, queue.Count, "Count for newly created queue is not correct.");

            queue.Enqueue(34);
            Assert.AreEqual(1, queue.Count, "Count for queue with 1 element is not correct.");

            queue.Enqueue(55);
            Assert.AreEqual(2, queue.Count, "Count for queue with 2 elements is not correct.");

            Assert.AreEqual(34, queue.Dequeue(), "Popped element is not correct.");
            Assert.AreEqual(1, queue.Count, "Count is not correct.");

            Assert.AreEqual(55, queue.Dequeue(), "Popped element is not correct.");
            Assert.AreEqual(0, queue.Count, "Count for empty queue after popping the last element not correct.");
        }

        [TestMethod]
        public void ToArrayShouldReturnArrayWithElements()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(-2);
            queue.Enqueue(9);
            queue.Enqueue(45);

            CollectionAssert.AreEqual(new int[] { 5, -2, 9, 45 }, queue.ToArray(), "ToArray does not return correct order of elements");
        }

        [TestMethod]
        public void ToArrayOfEmptyStackShouldReturnEmptyArray()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            CollectionAssert.AreEqual(new int[] { }, queue.ToArray(), "ToArray does not return empty array for empty queue.");
        }
    }
}
