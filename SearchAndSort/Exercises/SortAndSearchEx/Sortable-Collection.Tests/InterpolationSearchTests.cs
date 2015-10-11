namespace Sortable_Collection.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class InterpolationSearchTests
    {
        private static readonly Random Random = new Random();

        [TestMethod]
        public void TestWithEmptyCollectionShouldReturnMissingElement()
        {
            var collection = new SortableCollection<int>();
            this.ApplyDelegates(ref collection);
            var result = collection.InterpolationSearch(0);
            var expected = Array.BinarySearch(collection.ToArray(), 0);

            Assert.AreEqual(expected, result, "No elements are present in an empty collection; method should return -1.");
        }

        [TestMethod]
        public void TestWithMissingElement()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);
            this.ApplyDelegates(ref collection);
            var result = collection.InterpolationSearch(0);
            var expected = -1;

            Assert.AreEqual(expected, result, "Missing element should return -1.");
        }

        [TestMethod]
        public void TestWithItemAtMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);
            ApplyDelegates(ref collection);
            var result = collection.InterpolationSearch(3);
            var expected = Array.BinarySearch(collection.ToArray(), 3);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithItemToTheLeftOfMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);
            this.ApplyDelegates(ref collection);

            var result = collection.InterpolationSearch(2);
            var expected = Array.BinarySearch(collection.ToArray(), 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithItemToTheRightOfMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);
            this.ApplyDelegates(ref collection);

            var result = collection.InterpolationSearch(4);
            var expected = Array.BinarySearch(collection.ToArray(), 4);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithMultipleMissingKeysSmallerThanMinimum()
        {
            const int NumberOfChecks = 10000;
            const int NumberOfElements = 1000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);
            this.ApplyDelegates(ref collection);

            for (int i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(int.MinValue, collection.Items[0]);

                int result = collection.InterpolationSearch(item);

                Assert.AreEqual(-1, result);
            }
        }

        [TestMethod]
        public void TestWithMultipleMissingKeysLargerThanMaximum()
        {
            const int NumberOfChecks = 10000;
            const int NumberOfElements = 1000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);
            this.ApplyDelegates(ref collection);

            for (int i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(collection.Items[collection.Count - 1], int.MaxValue);

                int result = collection.InterpolationSearch(item);

                Assert.AreEqual(-1, result);
            }
        }

        // Below test are unappliable because we can not predict the first  index where the InterpolationSearch will check and find the searched item
        //[TestMethod]
        //public void TestWithMultipleKeys()
        //{
        //    const int NumberOfElements = 10000;

        //    var elements = new int[NumberOfElements];

        //    for (int i = 0; i < NumberOfElements; i++)
        //    {
        //        elements[i] = Random.Next(-100, 100);
        //    }

        //    Array.Sort(elements);

        //    var collection = new SortableCollection<int>(elements);
        //    this.ApplyDelegates(ref collection);

        //    foreach (var element in elements)
        //    {
        //        int expected = Array.IndexOf(elements, element);
        //        int result = collection.InterpolationSearch(element);

        //        Assert.AreEqual(expected, result);
        //    }
        //}

        //[TestMethod]
        //public void TestWithRepeatingItemShouldReturnFirstDiscoveredIndex()
        //{
        //    var collection = new SortableCollection<int>(0, 3, 3, 3, 3, 7, 7, 7, 7, 7, 7);
        //    this.ApplyDelegates(ref collection);

        //    var result = collection.InterpolationSearch(3);

        //    Assert.AreEqual(1, result);
        //}

        private void ApplyDelegates(ref SortableCollection<int> collection)
        {
            collection = new SortableCollection<int>(collection.Items, Subtract, Multiply);
        }

        private int Multiply(int a, int b)
        {
            return a * b;
        }

        private int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
