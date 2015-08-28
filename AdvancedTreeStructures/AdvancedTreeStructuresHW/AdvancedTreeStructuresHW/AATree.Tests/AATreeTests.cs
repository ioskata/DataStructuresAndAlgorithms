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
            Assert.AreEqual(3, result.Value);
        }
    }
}
