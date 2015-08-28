using AATree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AATreeTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(3);
            var result = tree.Remove(3);
            Console.WriteLine(result);
        }
    }
}
