using System;
using System.Text;


namespace BinaryTree
{
    static class Constants
    {
        public const int MAX_SIZE = 10;
    }

    public class Node
    {
        public int value;
        public Node left = null;
        public Node right = null;

        public Node()
        {
            value = 0;
            left = null;
            right = null;
        }

        public Node(int newItem)
        {
            value = newItem;
            left = null;
            right = null;
        }
    }

    public class BTree : Node
    {
        public Node root = null;
        public Node currentNode = null;
        static int mcount = 0;

        public void insert(int item)
        {
            if (root == null)
            {
                root = new Node(item);
                currentNode = root;
            }
            else
            {
                Node parentNode = new Node();
                if (item < currentNode.value)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new Node();
                        currentNode.left.value = item;
                    }
                    else
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.left;
                        insert(item);
                    }
                }
                else if (item > currentNode.value)
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = new Node();
                        currentNode.right.value = item;
                    }
                    else
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.right;
                        insert(item);
                    }
                }
                currentNode = root;
            }
        }

        public void display(int i)
        {
            if (mcount < Constants.MAX_SIZE)
            {
                Console.Write(i);
                Console.Write(" ");
                mcount++;
            }

            if(mcount == Constants.MAX_SIZE)
            {
                mcount = 0;
            }
        }

        public void inorder(ref Node node, Action<int> f)
        {
            if(node != null)
            {
                if (node.left != null)
                {
                    inorder(ref node.left, f);
                }

                f(node.value);

                if (node.right != null)
                {
                    inorder(ref node.right, f);
                }
            }
        }

        public void preorder(ref Node node, Action<int> f)
        {
            if (node != null)
            {
                f(node.value);
                if (node.left != null)
                {
                    preorder(ref node.left, f);
                }

                if (node.right != null)
                {
                    preorder(ref node.right, f);
                }
            }

        }

        public void postorder(ref Node node, Action<int> f)
        {
            if (node != null)
            {
                if (node.left != null)
                {
                    postorder(ref node.left, f);
                }

                if (node.right != null)
                {
                    postorder(ref node.right, f);
                }

                f(node.value);
            }
        }
    }
}
