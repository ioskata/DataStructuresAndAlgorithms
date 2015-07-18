namespace Task01PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tree<T>
    {
        public Tree(T value, Tree<T> parent = null, params Tree<T>[] children)
        {
            this.Value = value;
            this.Parent = parent;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
            }
        }

        public T Value { get; private set; }

        public IList<Tree<T>> Children { get; set; }

        public Tree<T> Parent { get; set; }
    }
}
