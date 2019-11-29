using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Node
    //Modified binary search tree class that uses mobile objects and sorts them based on their distance from the origin
    //Parent node tracking works with integers but not mobile objects. I've reworked it half a dozen times and it just 
    //won't work with MOBS, even though everything I tried works perfectly with Integers
    {
        public MobileObject value;
        // public int value;
        public Node left;
        public Node right;
        public Color colour;
        //parent node

        public Node parent;
    }

    class BinarySearchTree
    {
        public Node insert(Node root, MobileObject /*int*/ v)
        {


            if (root.value == null)
            {
                root = new Node();
                root.value = v;
                root.parent = null;
            }

            // insertion logic, if the value (v )is < root, insert to the root.left
            // otherwise it's >=, so insert to the right

            //Objects are sorted based on their distance from origin
            //Parent tracking takes place here, but won't work for MOBS no matter how you do it
            else if (v.Dfo < root.value.Dfo)
            {


                Node Left = insert(root.left, v);
                root.left = Left;

                Left.parent = root;




            }
            else
            {


                Node Right = insert(root.right, v);
                root.right = Right;

                Right.parent = root;

            }

            return root;
        }
        // Lab:  Take the code from here, and implement 3 different traversals  as strings
        // public string traverse (Node root)

        //Each traverse has its integer BST printout lines commented out for testing
        public void traverse(Node root)
        {
            if (root.value == null)
            {
                return;
            }
            Console.WriteLine("Name: " + root.value.Name + " ID: " + root.value.ID1 + " Distance From Origin: " + root.value.Dfo);
            if (root.parent == null)
            {
                Console.WriteLine("Node parent: Null");
            }
            else
            {
                Console.WriteLine(" ^ Parent: " + root.value.Name + " ID: " + root.value.ID1 + " Distance From Origin: " + root.value.Dfo);
            }
            /*Console.Out.WriteLine("Node :" + root.value);
            if (root.parent == null)
            {
                Console.Out.WriteLine("Node parent ^ : NUll");
            }
            else
            {
                Console.Out.WriteLine("Node parent ^ :" + root.parent.value);
            } */

            traverse(root.left);
            traverse(root.right);


        }

        public void traverseInOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            traverseInOrder(root.left);
            if (root.value != null)
            {
                Console.WriteLine("Name: " + root.value.Name + " ID: " + root.value.ID1 + " Distance From Origin: " + root.value.Dfo);
            }
            /* Console.Out.WriteLine("Node :" + root.value);
             if (root.parent == null)
             {
                 Console.Out.WriteLine("Node parent ^ : NUll");
             }
             else
             {
                 Console.Out.WriteLine("Node parent ^ :" + root.parent.value);
             } */
            traverseInOrder(root.right);
        }
        public void traversePreOrder(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine("Name: " + root.value.Name + " ID: " + root.value.ID1 + " Distance From Origin: " + root.value.Dfo);
            if (root.parent == null)
            {
                Console.WriteLine("Node parent: Null");
            }
            else
            {
                Console.WriteLine(" ^ Parent: " + root.value.Name + " ID: " + root.value.ID1 + " Distance From Origin: " + root.value.Dfo);
            }
            /*  Console.Out.WriteLine("Node :" + root.value);
              if (root.parent == null)
              {
                  Console.Out.WriteLine("Node parent ^ : NUll");
              }
              else
              {
                  Console.Out.WriteLine("Node parent ^ :" + root.parent.value);
              } */
            traversePreOrder(root.left);
            traversePreOrder(root.right);
        }
        public void traversePostOrder(Node root)
        {
            if (root == null)
            {
                return;
            }
            traversePostOrder(root.left);
            traversePostOrder(root.right);
            Console.WriteLine("Name: " + root.value.Name + " ID: " + root.value.ID1 + " Distance From Origin: " + root.value.Dfo);
            if (root.parent == null)
            {
                Console.WriteLine("Node parent: Null");
            }
            else
            {
                Console.WriteLine(" ^ Parent: " + root.value.Name + " ID: " + root.value.ID1 + " Distance From Origin: " + root.value.Dfo);
            }
            /* Console.Out.WriteLine("Node :" + root.value);
             if (root.parent == null)
             {
                 Console.Out.WriteLine("Node parent ^ : NUll");
             }
             else
             {
                 Console.Out.WriteLine("Node parent ^ :" + root.parent.value);
             } */
        }

        public String findSmallest(Node root)
        {
            if (root == null)
            {
                return ("null root");
            }
            if (root.left == null)
            {
                return (root.value.ToString());
            }
            return (findSmallest(root.left));
        }

        public void breadthFirstTraverse(Node root)
        {
            Queue<Node> Q = new Queue<Node>();
            Q.Enqueue(root);
            while (Q.Count > 0)
            {
                Node next = Q.Dequeue();
                Console.WriteLine("Name: " + next.value.Name + " ID: " + next.value.ID1 + " Distance From Origin: " + next.value.Dfo);
                if (next.parent == null)
                {
                    Console.WriteLine("Node parent: Null");
                }
                else
                {
                    Console.WriteLine(" ^ Parent: " + next.value.Name + " ID: " + next.value.ID1 + " Distance From Origin: " + next.value.Dfo);
                }
                /* Console.Out.WriteLine("Node :" + next.value);
                 if (next.parent == null)
                 {
                     Console.Out.WriteLine("Node parent ^ : NUll");
                 }
                 else
                 {
                     Console.Out.WriteLine("Node parent ^ :" + next.parent.value);
                 }
                 */
                if (next.left != null)
                {
                    Q.Enqueue(next.left);
                }
                if (next.right != null)
                {
                    Q.Enqueue(next.right);
                }
            }
        }

        // For students to implement in the lab 
        // note that in order, pre order and post order are all just rearranging the order
        // of the traverse method basically
        /*
        public string inOrder(Node root)
        { return ""; }

        public string preOrder(Node root)
        { return ""; }

        public string postOrder(Node root)
        { return ""; }

        public string breadthFirst(Node root)
        { return ""; } */

    }
}
