namespace Implementations.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Implementations;

    [TestClass]
    public class PriorityQueueTests
    {
        private class Student : IComparable<Student>, IEquatable<Student>
        {
            public Student(string firstName, int age)
            {
                this.FirstName = firstName;
                this.Age = age;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

            public int CompareTo(Student other)
            {
                return this.Age.CompareTo(other.Age);
            }

            public bool Equals(Student other)
            {
                return this.Age == other.Age &&
                    this.FirstName == other.FirstName &&
                    this.LastName == other.LastName;
            }
        }

        [TestMethod]
        public void NewlyInstantiatedPQShouldHaveCountZero()
        {
            PriorityQueue<string> pq = new PriorityQueue<string>();
            Assert.AreEqual(0, pq.Count);
        }

        [TestMethod]
        public void AddingElementToPQShouldReturnCount1()
        {
            PriorityQueue<Student> pq = new PriorityQueue<Student>();
            var pesho = new Student("Pesho", 23);
            pq.Enqueue(pesho);
            Assert.AreEqual(1, pq.Count);
            Assert.AreEqual(pesho, pq.Peek());
            Assert.AreEqual(pesho, pq.Dequeue());
            Assert.AreEqual(0, pq.Count);
        }

        [TestMethod]
        public void DequeueingSomeElementsShouldBeInCorrectOrder()
        {
            PriorityQueue<Student> pq = new PriorityQueue<Student>();
            var pesho = new Student("Pesho", 23);
            var gosho = new Student("Gosho", 35);
            var marijka = new Student("Maria", 69);
            var gergana = new Student("Gergana", 14);
            pq.Enqueue(pesho);
            pq.Enqueue(gosho);
            pq.Enqueue(marijka);
            pq.Enqueue(gergana);

            Assert.AreEqual(4, pq.Count);
            Assert.AreEqual(marijka, pq.Peek());
            Assert.AreEqual(marijka, pq.Dequeue());
            Assert.AreEqual(gosho, pq.Dequeue());
            Assert.AreEqual(2, pq.Count);
        }

        [TestMethod]
        public void DequeueingElementsWithSamePriorityShouldReturnTheFirstAdded()
        {
            PriorityQueue<Student> pq = new PriorityQueue<Student>();
            var pesho = new Student("Pesho", 23);
            var gosho = new Student("Gosho", 35);
            var gergana = new Student("Gergana", 14);
            var marijka = new Student("Maria", 35);
            pq.Enqueue(pesho);
            pq.Enqueue(gosho);
            pq.Enqueue(gergana);
            pq.Enqueue(marijka);

            Assert.AreEqual(4, pq.Count);
            Assert.AreEqual(gosho, pq.Peek());
            Assert.AreEqual(gosho, pq.Dequeue());
            Assert.AreEqual(marijka, pq.Dequeue());
            Assert.AreEqual(pesho, pq.Dequeue());
            Assert.AreEqual(gergana, pq.Dequeue());
            Assert.AreEqual(0, pq.Count);
        }
    }
}
