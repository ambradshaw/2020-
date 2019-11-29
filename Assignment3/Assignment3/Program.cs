using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class Program
    {
        //Program that will test the efficiency of different data structures in pushing/popping and enqueuing/dequeuing MobileObjects
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            CircularList cList = CircularList.Create();
            CircularArray<MobileObject> cArray = CircularArray<MobileObject>.Create(1);
            LinkedList list = LinkedList.Create();
            GenericArray<MobileObject> array = GenericArray<MobileObject>.Create(1);
            CircularList cList2 = CircularList.Create();
            CircularArray<MobileObject> cArray2 = CircularArray<MobileObject>.Create(1);
            LinkedList list2 = LinkedList.Create();
            GenericArray<MobileObject> array2 = GenericArray<MobileObject>.Create(1);
            Stopwatch cListWatch = new Stopwatch();
            Stopwatch listWatch = new Stopwatch();
            Stopwatch arrayWatch = new Stopwatch();
            Stopwatch cArrayWatch = new Stopwatch();
            Stopwatch cListWatch2 = new Stopwatch();
            Stopwatch listWatch2 = new Stopwatch();
            Stopwatch arrayWatch2 = new Stopwatch();
            Stopwatch cArrayWatch2 = new Stopwatch();
            int testValue = 10001;

            MobileObject[] testArray = new MobileObject[testValue];
            //An array of testValue length is populated with a random mix of NPC and vehicle objects
            for(int i = 0; i<testArray.Length; i++)
            {
                //Index 0 will always be an NPC object for testing
                if (i == 0)
                {
                    testArray[i] = new NPC("", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
                }
                //Index 6 will always be a vehicle object for testing
                else if (i == 6)
                {
                    testArray[i] = new Vehicle("", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
                }
                int flag = rnd.Next(0, 2);
                if (flag == 0)
                {
                    testArray[i] = new NPC("", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
                }
                else
                {
                    testArray[i] = new Vehicle("", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
                }
                
            }

            //Each data structure enqueues each entry in the testArray of objects, then dequeues all of those objects
            //This is what is being timed
                     cListWatch.Start();
                       foreach(MobileObject obj in testArray)
                       {
                           cList.enqueue(obj);
                       }
                       foreach (MobileObject obj in testArray)
                       {
                         cList.dequeue();
                       } 
                       cListWatch.Stop();
                       listWatch.Start();
                       foreach (MobileObject obj in testArray)
                       {
                           list.enqueue(obj);
                       }
                       foreach (MobileObject obj in testArray)
                       {
                           list.dequeue();
                       }
                       listWatch.Stop();
                       cArrayWatch.Start();
                       foreach (MobileObject obj in testArray)
                       {
                           cArray.enqueue(obj);
                       }
                      foreach (MobileObject obj in testArray)
                       {
                          cArray.dequeue();
                       }
                       cArrayWatch.Stop();
                       arrayWatch.Start();
                       foreach (MobileObject obj in testArray)
                       {
                           array.enqueue(obj);
                       }
                       foreach (MobileObject obj in testArray)
                       {
                           array.dequeue();
                       }
                       arrayWatch.Stop();

            /*

                       Console.Out.WriteLine("cList");
                       Console.Out.WriteLine("");
                       cList.printAllForward();
                       Console.Out.WriteLine("");
                       Console.Out.WriteLine("List");
                       Console.Out.WriteLine("");
                       list.printAllForward();
                       Console.Out.WriteLine("");

                       Console.Out.WriteLine("cArray");
                       Console.Out.WriteLine("");
                       cArray.printAll();

                       Console.Out.WriteLine("");
                       Console.Out.WriteLine("Array");
                       Console.Out.WriteLine("");
                       array.printAllForward();


                  
                       */

            //Each data structure pushes each entry in the testArray of objects, then pops all of those objects
            //This is what is being timed
            cListWatch2.Start();
            foreach (MobileObject obj in testArray)
            {
                cList2.push(obj);
            }
            foreach (MobileObject obj in testArray)
            {
                cList2.pop();
            } 
            cListWatch2.Stop();
            listWatch2.Start();
            foreach (MobileObject obj in testArray)
            {
                list2.push(obj);
            }
            foreach (MobileObject obj in testArray)
            {
                list2.pop();
            }
            listWatch2.Stop();
            cArrayWatch2.Start();
            foreach (MobileObject obj in testArray)
            {
                cArray2.push(obj);
            }
            foreach (MobileObject obj in testArray)
            {
                cArray2.pop();
            }
            cArrayWatch2.Stop();
            arrayWatch2.Start();
            foreach (MobileObject obj in testArray)
            {
                array2.push(obj);
            }
            foreach (MobileObject obj in testArray)
            {
                array2.pop();
            }
            arrayWatch2.Stop();

         /*   Console.Out.WriteLine("cList");
            Console.Out.WriteLine("");
            cList2.printAllForward();
            Console.Out.WriteLine("");
            Console.Out.WriteLine("List");
            Console.Out.WriteLine("");
            list2.printAllForward();
            Console.Out.WriteLine("");

            Console.Out.WriteLine("cArray");
            Console.Out.WriteLine("");
            cArray2.printAll();

            Console.Out.WriteLine("");
            Console.Out.WriteLine("Array");
            Console.Out.WriteLine("");
            array2.printAllForward();
            */

            Console.Out.WriteLine("");
            Console.Out.WriteLine("Elapsed Time spent queuing and dequeuing " + (testValue - 1) + " Objects: ");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("CircularList time(ms): " + cListWatch.ElapsedMilliseconds + " or " + (cListWatch.ElapsedMilliseconds / 1000) + " seconds");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("LinkedList time(ms): " + listWatch.ElapsedMilliseconds + " or " + (listWatch.ElapsedMilliseconds / 1000) + " seconds");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("CircularArrayList time(ms): " + cArrayWatch.ElapsedMilliseconds + " or " + (cArrayWatch.ElapsedMilliseconds / 1000) + " seconds");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("ArrayList time(ms): " + arrayWatch.ElapsedMilliseconds + " or " + (arrayWatch.ElapsedMilliseconds / 1000) + " seconds");

            Console.Out.WriteLine("");
            Console.Out.WriteLine("Elapsed Time spent pushing and popping " + (testValue - 1) + " Objects: ");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("CircularList time(ms): " + cListWatch2.ElapsedMilliseconds + " or " + (cListWatch2.ElapsedMilliseconds / 1000) + " seconds");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("LinkedList time(ms): " + listWatch2.ElapsedMilliseconds + " or " + (listWatch2.ElapsedMilliseconds / 1000) + " seconds");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("CircularArrayList time(ms): " + cArrayWatch2.ElapsedMilliseconds + " or " + (cArrayWatch2.ElapsedMilliseconds / 1000) + " seconds");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("ArrayList time(ms): " + arrayWatch2.ElapsedMilliseconds + " or " + (arrayWatch2.ElapsedMilliseconds / 1000) + " seconds");

            /* TL;DR
             * List structures are much faster than Arraylist ones for both stack operations and queue operations
             * For both tests list structures will take (at most) tens of milliseconds in cases where arrayList
             * structures will take tens of thousands of milliseconds
             * */

            Console.ReadLine();
        }
    }
}
