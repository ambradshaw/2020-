using System;
using System.Diagnostics;
using System.Threading;

// Alan-Michael Bradshaw 0643996
//Driver class for program that tests insertion time for different tree structures using mobile objects
namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node();
            BinarySearchTree bst = new BinarySearchTree();
            AVLTree avl = new AVLTree();
            RB rb = new RB();
            SplayTree<MobileObject, MobileObject> splay = new SplayTree<MobileObject, MobileObject>();
            Stopwatch bstWatch = new Stopwatch();
            Stopwatch avlWatch = new Stopwatch();
            Stopwatch rbWatch = new Stopwatch();
            Stopwatch splayWatch = new Stopwatch();
            //My laptop refuses to load more than 100 or so objects, it just won't do it 
            MobileObject[] MOBArray = new MobileObject[100];
            MobileObject[] MOBArray2 = new MobileObject[20];
            Random rnd = new Random();

            //testing
            for (int i = 0; i < MOBArray2.Length; i++)
            {
                MOBArray2[i] = new Vehicle(i.ToString(), i, i, i, i, i, i);
            }

            foreach(MobileObject item in MOBArray2)
            {
                bst.insert(root, item);
                avl.insert(root, item);
                rb.Insert(item);
                splay.Add(item, item);

            }

            Console.WriteLine("rb tree find function test: found matching mob, dfo = " + MOBArray2[3].Dfo);

            Console.WriteLine();

            //For sorted insert
            for (int i = 0; i<MOBArray.Length; i++)
            {
                MOBArray[i] = new Vehicle(i.ToString(), i, i, i, i, i, i);
            }



            //Unsorted insert
            /*    for(int i = 0; i<MOBArray.Length; i++)
            {
                MOBArray[i] = new Vehicle(i.ToString(), i, rnd.Next(100), rnd.Next(100), rnd.Next(100), rnd.Next(100), rnd.Next(100));
            } */


            bstWatch.Start();
             foreach( MobileObject item in MOBArray)
             {
                 bst.insert(root, item);
             }
            bstWatch.Stop();
            avlWatch.Start();
            foreach ( MobileObject item in MOBArray)
             {

                 avl.insert(root, item);
             }
            avlWatch.Stop();
            rbWatch.Start();
            foreach ( MobileObject item in MOBArray)
            {

                rb.Insert(item);

            }
            rbWatch.Stop();
            splayWatch.Start();
            foreach ( MobileObject item in MOBArray)
            {

                splay.Add(item, item);
            }
            splayWatch.Stop();

            Console.WriteLine("BST time(ticks) = " + bstWatch.ElapsedTicks);
            Console.WriteLine("AVL time(ticks) = " + avlWatch.ElapsedTicks);
            Console.WriteLine("RB time(ticks) = " + rbWatch.ElapsedTicks);
            Console.WriteLine("splay time(ticks) = " + splayWatch.ElapsedTicks);
            Console.ReadLine();
        }
    }
}
