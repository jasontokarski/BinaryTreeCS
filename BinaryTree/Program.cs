using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(10);
            BTree tree = new BTree() ;
            List<int> values = new List<int>(Constants.MAX_SIZE);

            for (int i = 0; i < values.Capacity; i++)
            {
                var nextRand = 0;
                nextRand = rand.Next(10);
                if(!(values.Contains(nextRand)))
                {
                    values.Insert(i, nextRand);
                }
                else
                {
                    --i;
                }
            }

            foreach (int value in values)
            {
                tree.insert(value);
            }

            Console.Write("Inorder traversal: ");
            tree.inorder(ref tree.root, tree.display);
            Console.Write("\n");

            Console.Write("Preorder traversal: ");
            tree.preorder(ref tree.root, tree.display);
            Console.Write("\n");

            Console.Write("Postorder traversal: ");
            tree.postorder(ref tree.root, tree.display);
            Console.Write("\n");

            Console.Read();
        }
    }
}
