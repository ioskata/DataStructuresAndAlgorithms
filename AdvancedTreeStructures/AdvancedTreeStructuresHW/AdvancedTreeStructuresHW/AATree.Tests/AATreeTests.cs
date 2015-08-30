namespace AATree.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AATreeTests
    {
        [TestMethod]
        public void AddRemoveSingleElementShouldWorkCorrectly()
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(3);
            var result = tree.Remove(3);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void RemoveSingleElementFromMultipleAdded()
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(3);
            tree.Add(20);
            var newRoot = tree.Remove(20);

            Assert.AreEqual(3, newRoot.Value);
        }

        [TestMethod]
        public void DachevRemoveSingleElementFromMultipleAdded()
        {
            AATreeDachev<int> tree = new AATreeDachev<int>();
            tree.Add(3);
            tree.Add(20);
            tree.Remove(20);
            tree.Remove(5);
            Assert.AreEqual(1, tree.Count);
        }
    }
}
