using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task07LinkedList;
using System.Collections.Generic;

namespace SingleIndexedLinkedList.Tests
{
    [TestClass]
    public class SingleIndexedLinkedListUnitTests
    {
        // test
        // Add
        // Remove by index
        // FirstIndex
        // LastIndex
        private const string MESSAGE_COUNTNOTMATCHING = "Items count is not correct.";
        private const string MESSAGE_FIRSTINDEXOF = "FirstIndexOf is not correct";
        private const string MESSAGE_LASTINDEXOF = "LastIndexOf is not correct";

        [TestMethod]
        public void AddSingleElementIntoEmptyCollection()
        {
            var list = new SingleIndexedLinkedList<int>();

            list.Add(3);

            Assert.AreEqual(1, list.Count, MESSAGE_COUNTNOTMATCHING);
            Assert.AreEqual(0, list.FirstIndexOf(3), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(0, list.LastIndexOf(3), MESSAGE_LASTINDEXOF);
        }

        [TestMethod]
        public void AddMultipleElementsWithoutRepetitions()
        {
            var list = new SingleIndexedLinkedList<int>();

            list.Add(4);
            list.Add(58);
            list.Add(659816519);
            list.Add(165965);

            Assert.AreEqual(4, list.Count, MESSAGE_COUNTNOTMATCHING);
            Assert.AreEqual(2, list.FirstIndexOf(659816519), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(3, list.FirstIndexOf(165965), MESSAGE_FIRSTINDEXOF + " Item at last index.");
            Assert.AreEqual(2, list.LastIndexOf(659816519), MESSAGE_LASTINDEXOF);
        }

        [TestMethod]
        public void AddMultipleElementsWithRepetitions()
        {
            var list = new SingleIndexedLinkedList<int>();

            list.Add(4);
            list.Add(58);
            list.Add(659816519);
            list.Add(165965);
            list.Add(659816519);
            list.Add(165965);

            Assert.AreEqual(6, list.Count, MESSAGE_COUNTNOTMATCHING);
            Assert.AreEqual(2, list.FirstIndexOf(659816519), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(0, list.FirstIndexOf(4), MESSAGE_FIRSTINDEXOF + " Item at index 0.");
            Assert.AreEqual(4, list.LastIndexOf(659816519), MESSAGE_LASTINDEXOF);
            Assert.AreEqual(5, list.LastIndexOf(165965), MESSAGE_LASTINDEXOF + " Item at last index.");
        }

        [TestMethod]
        public void RemoveSingleElementFromListWithoutRepetitions()
        {
            var list = new SingleIndexedLinkedList<int>();

            list.Add(4);
            list.Add(58);
            list.Add(659816519);
            list.Add(165965);

            list.Remove(2);

            Assert.AreEqual(3, list.Count, MESSAGE_COUNTNOTMATCHING);
            Assert.AreEqual(-1, list.FirstIndexOf(659816519), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(2, list.FirstIndexOf(165965), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(-1, list.LastIndexOf(659816519), MESSAGE_LASTINDEXOF);

            var expectedList = this.FillIntoList(list);
            CollectionAssert.AreEqual(expectedList, new List<int>() { 4, 58, 165965 }, "Elements' order is not correct.");
        }

        [TestMethod]
        public void RemoveElementAtIndexZero()
        {
            var list = new SingleIndexedLinkedList<int>();

            list.Add(4);
            list.Add(58);
            list.Add(659816519);
            list.Add(165965);

            list.Remove(0);

            Assert.AreEqual(3, list.Count, MESSAGE_COUNTNOTMATCHING);
            Assert.AreEqual(-1, list.FirstIndexOf(4), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(2, list.FirstIndexOf(165965), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(-1, list.LastIndexOf(4), MESSAGE_LASTINDEXOF);

            var expectedList = this.FillIntoList(list);
            CollectionAssert.AreEqual(expectedList, new List<int>() { 58,659816519, 165965 }, "Elements' order is not correct.");
        }

        [TestMethod]
        public void RemoveNonRepetitiveElementFromListWithRepetitions()
        {
            var list = new SingleIndexedLinkedList<int>();

            list.Add(4);
            list.Add(58);
            list.Add(659816519);
            list.Add(165965);
            list.Add(659816519);
            list.Add(165965);

            list.Remove(1);

            Assert.AreEqual(5, list.Count, MESSAGE_COUNTNOTMATCHING);
            Assert.AreEqual(-1, list.FirstIndexOf(58), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(-1, list.LastIndexOf(58), MESSAGE_LASTINDEXOF);
            Assert.AreEqual(1, list.FirstIndexOf(659816519), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(3, list.LastIndexOf(659816519), MESSAGE_LASTINDEXOF);

            var expectedList = this.FillIntoList(list);
            CollectionAssert.AreEqual(expectedList, new List<int>() { 4, 659816519, 165965, 659816519, 165965 }, "Elements' order is not correct.");
        }

        [TestMethod]
        public void RemoveRepetitiveElementFromListWithRepetitions()
        {
            var list = new SingleIndexedLinkedList<int>();

            list.Add(4);
            list.Add(58);
            list.Add(659816519);
            list.Add(165965);
            list.Add(659816519);
            list.Add(165965);

            list.Remove(2);

            Assert.AreEqual(5, list.Count, MESSAGE_COUNTNOTMATCHING);
            Assert.AreEqual(1, list.FirstIndexOf(58), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(1, list.LastIndexOf(58), MESSAGE_LASTINDEXOF);
            Assert.AreEqual(3, list.FirstIndexOf(659816519), MESSAGE_FIRSTINDEXOF);
            Assert.AreEqual(3, list.LastIndexOf(659816519), MESSAGE_LASTINDEXOF);

            var expectedList = this.FillIntoList(list);
            CollectionAssert.AreEqual(expectedList, new List<int>() { 4, 58, 165965, 659816519, 165965 }, "Elements' order is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Removing from empty list should throw InvalidOperationException.")]
        public void RemoveElementFromEmptyList()
        {
            var list = new SingleIndexedLinkedList<int>();

            list.Remove(2);
        }


        private List<int> FillIntoList(SingleIndexedLinkedList<int> linkedList)
        {
            var list = new List<int>();

            foreach (var item in linkedList)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
