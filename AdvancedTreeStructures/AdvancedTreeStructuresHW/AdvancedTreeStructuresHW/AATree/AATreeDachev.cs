using System;

namespace AATree
{
    public class AATreeDachev<T> where T : IComparable<T>
    {
        private class TreeNode<T>
        {
            public T Value { get; set; }

            public int Level { get; set; }

            public TreeNode<T> leftChild;
            public TreeNode<T> rightChild;

            public TreeNode(T value, int level)
            {
                this.Value = value;
                this.Level = level;
            }
        }

        private TreeNode<T> root;

        public int Count { get; set; }

        public AATreeDachev()
        {
            this.Count = 0;
        }

        public bool Add(T value)
        {
            if (this.Insert(ref this.root, value))
            {
                this.Count++;
                return true;
            }

            return false;
        }

        private bool Insert(ref TreeNode<T> node, T value)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value, 1);
                return true;
            }

            int comparisonResult = value.CompareTo(node.Value);
            if (comparisonResult < 0)
            {
                if (!Insert(ref node.leftChild, value))
                {
                    return false;
                }
            }
            else if (comparisonResult > 0)
            {
                if (!Insert(ref node.rightChild, value))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            Skew(ref node);
            Split(ref node);

            return true;
        }

        public bool Remove(T value)
        {
            if (this.Delete(ref this.root, value))
            {
                this.Count--;
                return true;
            }
            return false;
        }

        private bool Delete(ref TreeNode<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            int comparisonResult = value.CompareTo(node.Value);
            if (comparisonResult < 0)
            {
                if (!Delete(ref node.leftChild, value))
                {
                    return false;
                }
            }
            else if (comparisonResult > 0)
            {
                if (!Delete(ref node.rightChild, value))
                {
                    return false;
                }
            }
            else
            {
                if (node.leftChild == null && node.rightChild == null)
                {
                    node = null;
                }
                else if (node.leftChild == null)
                {
                    node = node.rightChild;
                }
                else if (node.rightChild == null)
                {
                    node = node.leftChild;
                }
                else // Node with two children
                {
                    var inOrderPredecessor = this.FindInOrderPredecessor(node.leftChild);
                    node.Value = inOrderPredecessor.Value;
                    Delete(ref node.leftChild, inOrderPredecessor.Value);
                }
            }

            if (node != null && (node.leftChild != null && node.leftChild.Level < node.Level - 1 || node.rightChild != null && node.rightChild.Level != node.Level - 1))
            {
                node.Level--;
                if (node.rightChild != null && node.rightChild.Level > node.Level)
                {
                    node.rightChild.Level = node.Level;
                }

                this.Skew(ref node);
                this.Split(ref node);
            }

            return true;
        }

        private TreeNode<T> FindInOrderPredecessor(TreeNode<T> node)
        {
            var inOrderPredecessor = node;

            while (inOrderPredecessor.rightChild != null)
            {
                inOrderPredecessor = node.rightChild;
            }

            return inOrderPredecessor;
        }

        private void Skew(ref TreeNode<T> node)
        {
            if (node != null && node.leftChild != null && node.Level == node.leftChild.Level)
            {
                var leftNode = node.leftChild;
                node.leftChild = leftNode.rightChild;
                leftNode.rightChild = node;
                node = leftNode;
            }
        }

        private void Split(ref TreeNode<T> node)
        {
            if (node != null && node.rightChild != null && node.rightChild.rightChild != null && node.Level == node.rightChild.rightChild.Level)
            {
                var rightNode = node.rightChild;
                node.rightChild = rightNode.leftChild;
                rightNode.leftChild = node;
                rightNode.Level++;
                node = rightNode;
            }
        }
    }
}