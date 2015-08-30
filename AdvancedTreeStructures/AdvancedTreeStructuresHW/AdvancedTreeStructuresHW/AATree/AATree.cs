namespace AATree
{
    using System;
    using System.Collections.Generic;

    public class AATree<TValue> where TValue : IComparable<TValue>
    {
        private Node<TValue> root;

        public AATree()
        {
            //this.root = new Node<TValue>();
        }

        public int Count { get; set; }

        public Node<TValue> Add(TValue value)
        {
            Node<TValue> added = this.Insert(value, ref this.root);
            if (this.Count < 1)
            {
                this.root = added;
            }

            this.Count++;
            return added;
        }

        public Node<TValue> Remove(TValue value)
        {
            var deleted = this.Delete(value, ref this.root);
            this.Count--;
            return deleted;
        }

        private Node<TValue> Insert(TValue value, ref Node<TValue> nodeToInsertInto)
        {
            if (null == nodeToInsertInto)
            {
                return new Node<TValue>(value, null);
            }
            else if (value.CompareTo(nodeToInsertInto.Value) < 0)
            {
                nodeToInsertInto.left = Insert(value, ref nodeToInsertInto.left);
            }
            else if (value.CompareTo(nodeToInsertInto.Value) > 0)
            {
                nodeToInsertInto.right = Insert(value, ref nodeToInsertInto.right);
            }

            nodeToInsertInto = this.Skew(ref nodeToInsertInto);
            nodeToInsertInto = this.Split(ref nodeToInsertInto);

            return nodeToInsertInto;
        }

        private Node<TValue> Delete(TValue value, ref Node<TValue> rootToDeleteFrom)
        {
            if (null == rootToDeleteFrom)
            {
                return rootToDeleteFrom;
            }
            else if (value.CompareTo(rootToDeleteFrom.Value) > 0)
            {
                rootToDeleteFrom.right = Delete(value, ref rootToDeleteFrom.right);
            }
            else if (value.CompareTo(rootToDeleteFrom.Value) < 0)
            {
                rootToDeleteFrom.left = Delete(value, ref rootToDeleteFrom.left);
            }
            else
            {
                if (rootToDeleteFrom.left == null && rootToDeleteFrom.right == null)
                {
                    return null;
                }
                else if (null == rootToDeleteFrom.left)
                {
                    var l = rootToDeleteFrom.right; // successor of rootToDeleteFrom when left child is null
                    rootToDeleteFrom.right = Delete(l.Value, ref rootToDeleteFrom.right);
                    rootToDeleteFrom.Value = l.Value;
                }
                else
                {
                    var l = GetPredecessor(ref rootToDeleteFrom);
                    rootToDeleteFrom.left = Delete(l.Value, ref rootToDeleteFrom.left);
                    rootToDeleteFrom.Value = l.Value;
                }
            }

            rootToDeleteFrom = this.DecreaseLevel(ref rootToDeleteFrom);
            rootToDeleteFrom = this.Skew(ref rootToDeleteFrom);
            rootToDeleteFrom.right = this.Skew(ref rootToDeleteFrom.right);
            if (null != rootToDeleteFrom.right)
            {
                rootToDeleteFrom.right.right = this.Skew(ref rootToDeleteFrom.right.right);
            }

            rootToDeleteFrom = this.Split(ref rootToDeleteFrom);
            rootToDeleteFrom.right = this.Split(ref rootToDeleteFrom.right);
            return rootToDeleteFrom;
        }

        private Node<TValue> Split(ref Node<TValue> nodeToRebalance)
        {
            if (null == nodeToRebalance)
            {
                return null;
            }
            else if (null == nodeToRebalance.right || null == nodeToRebalance.right.right)
            {
                return nodeToRebalance;
            }
            else if (nodeToRebalance.level == nodeToRebalance.right.right.level)
            {
                var r = nodeToRebalance.right;
                nodeToRebalance.right = r.left;
                r.left = nodeToRebalance;
                r.level++;
                return r;
            }
            else
            {
                return nodeToRebalance;
            }
        }

        private Node<TValue> Skew(ref Node<TValue> nodeToRebalance)
        {
            if (nodeToRebalance == null)
            {
                return null;
            }
            else if (null == nodeToRebalance.left)
            {
                return nodeToRebalance;
            }
            else if (nodeToRebalance.left.level == nodeToRebalance.level)
            {
                var l = nodeToRebalance.left;
                nodeToRebalance.left = l.right;
                l.right = nodeToRebalance;
                return l;
            }
            else
            {
                return nodeToRebalance;
            }
        }

        private Node<TValue> DecreaseLevel(ref Node<TValue> rootToRemoveLinksFor)
        {
            int shouldBe = Math.Min(rootToRemoveLinksFor.left.level, rootToRemoveLinksFor.right.level) + 1;
            if (shouldBe.CompareTo(rootToRemoveLinksFor.level) < 0)
            {
                rootToRemoveLinksFor.level = shouldBe;
                if (shouldBe.CompareTo(rootToRemoveLinksFor.right.level) < 0)
                {
                    rootToRemoveLinksFor.right.level = shouldBe;
                }
            }

            return rootToRemoveLinksFor;
        }

        private Node<TValue> GetPredecessor(ref Node<TValue> childNode)
        {
            Queue<Node<TValue>> queue = new Queue<Node<TValue>>();
            queue.Enqueue(childNode);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (childNode == currentNode.left || childNode == currentNode.right)
                {
                    return currentNode;
                }

                queue.Enqueue(currentNode.left);
                queue.Enqueue(currentNode.right);
            }

            return null;
        }
    }
}
