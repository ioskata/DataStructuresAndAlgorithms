namespace ReversedList.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task06ReversedList;

    [TestClass]
    public class ReversedListUnitTests
    {
        private const string MESSAGE_NOTMATCHINGCOUNT = "Count does not match.";
        private const string MESSAGE_NOTMATCHINGCAPACITY = "Capacity does not match.";
        private const string MESSAGE_NOTCORRECTITEMS = "Items are not correct or in the correct order.";

        [TestMethod]
        public void AddElementToEmptyList()
        {
            var list = new ReversedList<int>();

            list.Add(2);

            Assert.AreEqual(1, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(1, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);

            var items = new List<int>();
            foreach (var item in list)
            {
                items.Add(item);
            }
            CollectionAssert.AreEqual(new List<int>() { 2 }, items, MESSAGE_NOTCORRECTITEMS);
        }

        [TestMethod]
        public void AddElementsWithSingleCapacityDoubling()
        {
            var list = new ReversedList<int>();

            list.Add(3);
            list.Add(45);
            list.Add(23000000);

            Assert.AreEqual(3, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(4, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);

            var items = new List<int>();
            foreach (var item in list)
            {
                items.Add(item);
            }
            CollectionAssert.AreEqual(new List<int>() { 23000000, 45, 3 }, items, MESSAGE_NOTCORRECTITEMS);
        }

        [TestMethod]
        public void AddElementsWithDoubleCapacityDoubling()
        {
            var list = new ReversedList<int>();

            list.Add(3);
            list.Add(45);
            list.Add(23000000);
            list.Add(24000000);
            list.Add(567);

            Assert.AreEqual(5, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(8, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);

            var items = new List<int>();
            foreach (var item in list)
            {
                items.Add(item);
            }
            CollectionAssert.AreEqual(items, new List<int>() { 567, 24000000, 23000000, 45, 3 }, "Items are not correct or in the correct order.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Removing by index should not be allowed when collection is empty.")]
        public void RemoveZeroIndexFromEmptyCollection()
        {
            var list = new ReversedList<int>();
            list.Remove(0);

            Assert.AreEqual(0, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(1, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Removing by index should not be allowed when collection is empty.")]
        public void RemoveBiggerIndexFromEmptyCollection()
        {
            var list = new ReversedList<int>();
            list.Remove(1);

            Assert.AreEqual(0, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(1, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Removing by index bigger than the index of the last added element should not be allowed.")]
        public void RemoveBiggerIndexBetweenEndAndCapacity()
        {
            var list = new ReversedList<int>();

            list.Add(3);
            list.Add(45);
            list.Add(23000000);
            list.Add(24000000);
            list.Add(567);

            list.Remove(6);

            Assert.AreEqual(5, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(8, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Removing by index bigger than the index of the last added element should not be allowed.")]
        public void RemoveBiggerIndexOutsideCapacity()
        {
            var list = new ReversedList<int>();

            list.Add(3);
            list.Add(45);
            list.Add(23000000);
            list.Add(24000000);
            list.Add(567);

            list.Remove(9);

            Assert.AreEqual(5, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(8, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Removing by index bigger than the index of the last added element should not be allowed.")]
        public void RemoveIndexEqualToCapacity()
        {
            var list = new ReversedList<int>();

            list.Add(3);
            list.Add(45);
            list.Add(23000000);
            list.Add(24000000);
            list.Add(567);

            list.Remove(8);

            Assert.AreEqual(5, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(8, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Removing by index bigger than the index of the last added element should not be allowed.")]
        public void RemoveIndexEqualToEnd()
        {
            var list = new ReversedList<int>();

            list.Add(3);
            list.Add(45);
            list.Add(23000000);
            list.Add(24000000);
            list.Add(567);

            list.Remove(5);

            Assert.AreEqual(5, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(8, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);
        }

        [TestMethod]
        public void RemoveTwiceTheSameIndex()
        {
            var list = new ReversedList<int>();

            list.Add(3);
            list.Add(45);
            list.Add(23000000);
            list.Add(24000000);
            list.Add(567);

            list.Remove(2);
            list.Remove(2);

            Assert.AreEqual(3, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(8, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);

            var items = new List<int>();
            foreach (var item in list)
            {
                items.Add(item);
            }

            CollectionAssert.AreEqual(items, new List<int>() { 567, 24000000, 3 }, MESSAGE_NOTCORRECTITEMS);

        }

        [TestMethod]
        public void RemoveByIndexInFilledCollection()
        {
            var list = new ReversedList<int>();

            list.Add(3);
            list.Add(45);
            list.Add(23000000);
            list.Add(24000000);
            list.Add(567);

            list.Remove(3);

            Assert.AreEqual(4, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(8, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);

            var items = new List<int>();
            foreach (var item in list)
            {
                items.Add(item);
            }

            CollectionAssert.AreEqual(items, new List<int>() { 567, 24000000, 23000000, 3 }, MESSAGE_NOTCORRECTITEMS);
        }

        [TestMethod]
        public void RemoveByIndexSinglePopulatedCollection()
        {
            var list = new ReversedList<int>();

            list.Add(3);

            list.Remove(0);

            Assert.AreEqual(0, list.Count, MESSAGE_NOTMATCHINGCOUNT);
            Assert.AreEqual(1, list.Capacity, MESSAGE_NOTMATCHINGCAPACITY);

            var items = new List<int>();
            foreach (var item in list)
            {
                items.Add(item);
            }

            CollectionAssert.AreEqual(items, new List<int>() { }, MESSAGE_NOTCORRECTITEMS);
        }
    }
}
