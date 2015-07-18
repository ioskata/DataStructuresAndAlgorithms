namespace Task01PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Task01PlayWithTreesClass
    {
        private static Dictionary<int, Tree<int>> foundNodes = new Dictionary<int, Tree<int>>();
        private static Tree<int> tree;
        private static int searchedPathSum = 0;
        private static int searchedSubtreeSum = 0;

        static void Main(string[] args)
        {
            ParseInput();

            var rootNode = FindRootNode();
            Console.WriteLine("Root node: {0}", rootNode.Value);

            var leafNodes = FindLeafNodes();
            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", leafNodes.Select(ln => ln.Value)));

            var middleNodes = FindMiddleNodes();
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes.Select(ln => ln.Value)));

            var longestPath = FindLongestPath(rootNode);
            Console.WriteLine("Longest Path: {0} (length = {1})", string.Join(" -> ", longestPath.Select(ln => ln.Value)), longestPath.Count());

            var pathsOfSearchedSum = FindPathsWithGivenSum(rootNode);
            StringBuilder formattedPaths = new StringBuilder();
            foreach (var path in pathsOfSearchedSum)
            {
                formattedPaths.AppendLine(string.Join(" -> ", path));
            }

            Console.WriteLine("Paths of sum {0}\n{1}", searchedPathSum, formattedPaths.ToString());

            var subtreesOfSearchedSum = FindSubtreesOfGivenSum(rootNode);
            StringBuilder formattedSubtrees = new StringBuilder();
            foreach (var subtree in subtreesOfSearchedSum)
            {
                formattedSubtrees.AppendLine(string.Join(" + ", subtree));
            }

            Console.WriteLine("Subtrees of sum {0}\n{1}", searchedSubtreeSum, formattedSubtrees.ToString());
        }

        private static List<List<int>> FindSubtreesOfGivenSum(Tree<int> rootNode)
        {
            var resultSubtrees = new List<List<int>>();
            Stack<Tree<int>> dfsStack = new Stack<Tree<int>>();
            dfsStack.Push(rootNode);

            while (dfsStack.Count > 0)
            {
                var currentNode = dfsStack.Pop();
                var correctSubtree = GetSubtreeWithCorrectSum(currentNode);

                if (null != correctSubtree)
                {
                    resultSubtrees.Add(correctSubtree);
                }

                foreach (var child in currentNode.Children)
                {
                    dfsStack.Push(child);
                }
            }

            return resultSubtrees;
        }

        private static List<int> GetSubtreeWithCorrectSum(Tree<int> rootNode)
        {
            int sum = 0;
            var subtreeValues = new List<int>();

            Stack<Tree<int>> dfsStack = new Stack<Tree<int>>();
            dfsStack.Push(rootNode);

            while (dfsStack.Count > 0)
            {
                var currentNode = dfsStack.Pop();

                sum += currentNode.Value;
                subtreeValues.Add(currentNode.Value);

                foreach (var child in currentNode.Children)
                {
                    dfsStack.Push(child);
                }
            }

            if (sum != searchedSubtreeSum)
            {
                subtreeValues = null;
            }

            return subtreeValues;
        }

        // returns also paths that are not strictly starting from the root and finishing to a leaf
        private static Stack<int>[] FindPathsWithGivenSum(Tree<int> root)
        {
            Stack<Tree<int>> dfsStack = new Stack<Tree<int>>();
            var foundPaths = new Stack<Stack<int>>();

            dfsStack.Push(root);
            while (dfsStack.Count > 0)
            {
                var currentNode = dfsStack.Pop();
                var set = new Stack<int>();
                var node = currentNode;
                while (null != node)
                {
                    set.Push(node.Value);
                    if (set.Sum() == searchedPathSum)
                    {
                        foundPaths.Push(set);
                    }

                    node = node.Parent;
                }

                set = new Stack<int>();

                foreach (var child in currentNode.Children)
                {
                    dfsStack.Push(child);
                }
            }

            return foundPaths.ToArray();
        }

        private static IEnumerable<Tree<int>> FindLongestPath(Tree<int> root)
        {
            int maxDepth = 0;
            Stack<Tree<int>> dfsStack = new Stack<Tree<int>>();
            Queue<Tree<int>> paths = new Queue<Tree<int>>();
            Tree<int>[] longestPath = new Tree<int>[] { };

            dfsStack.Push(root);
            while (dfsStack.Count > 0)
            {
                var currentNode = dfsStack.Pop();
                if (currentNode.Children.Count == 0)
                {
                    var node = currentNode;
                    while (null != node)
                    {
                        paths.Enqueue(node);
                        node = node.Parent;

                    }

                    if (paths.Count >= maxDepth)
                    {
                        maxDepth = paths.Count;
                        longestPath = paths.ToArray();
                    }
                }

                paths.Clear();

                foreach (var child in currentNode.Children)
                {
                    dfsStack.Push(child);
                }


            }

            return longestPath;
        }

        private static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = foundNodes.Values
                .Where(n => n.Parent != null && n.Children.Count > 0)
                .OrderBy(n => n.Value);
            return middleNodes;
        }

        private static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = foundNodes.Values
                .Where(n => n.Children.Count == 0)
                .OrderBy(n => n.Value);
            return leafNodes;

        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = foundNodes.Values.FirstOrDefault(n => n.Parent == null);
            return rootNode;
        }

        private static void ParseInput()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodesCount - 1; i++)
            {
                var inputArr = (Console.ReadLine()).Split(new char[] { ' ' });
                int parentValue = int.Parse(inputArr[0]);
                int childValue = int.Parse(inputArr[1]);
                Tree<int> parentNode;
                Tree<int> childNode;

                if (foundNodes.ContainsKey(parentValue))
                {
                    parentNode = foundNodes[parentValue];
                }
                else
                {
                    parentNode = new Tree<int>(parentValue);
                    foundNodes[parentValue] = parentNode;
                }

                if (foundNodes.ContainsKey(childValue))
                {
                    childNode = foundNodes[childValue];
                }
                else
                {
                    childNode = new Tree<int>(childValue, parentNode);
                    foundNodes[childValue] = childNode;
                }

                parentNode.Children.Add(childNode);

                if (null == tree)
                {
                    tree = foundNodes[parentValue];
                }
            }

            searchedPathSum = int.Parse(Console.ReadLine());
            searchedSubtreeSum = int.Parse(Console.ReadLine());
        }
    }
}
