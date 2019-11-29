using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class CircularArray<T>
    {
        private T[] array;
        private int queueFront;
        private int queueRear;
        private int stackStart = 0;
        // Creates an array and initializes the front and rear
        // O(1) in time O (N) in size
        public CircularArray(int size)
        {
            array = new T[size + 1];
            queueFront = 0;
            queueRear = 0;
             stackStart = 0;
    }
        public static CircularArray<T> Create(int size)
        {
            return new CircularArray<T>(size);
        }

        public void enqueue(T value)  
                                      //Enqueue method that adds objects to the front of the structures queue
                                      //O(n^2)
        {
            queueRear++;
            if (queueRear > (array.Length - 1))
            {
                grow(array.Length*2);
            }
            T temp = array[0];
            T temp2 = array[0];
            for (int i = 1; i < array.Length - 1; i++)
            {
                temp2 = array[i];
                array[i] = temp;
                temp = temp2;

            }
            array[queueFront] = value;

        }

        public void push(T value)
            //push method that adds objects to the top of the structures stack
            //O(n^5)
        {
            if (array[queueFront] == null)
            {
                array[queueFront] = value;
                return;
            }

            int i = array.Length - 1;
            if (array[i] == null)
            {
                while (array[i - 1] == null)
                {
                    i--;
                }

                for (int u = i; u > 0; u--)
                {
                    if (u > 0)
                    {
                        array[u] = array[u - 1];
                    }
                }
                array[0] = value;
                return;
            }
            grow(array.Length + 1);
            i = array.Length - 1;
            while (array[i - 1] == null)
            {
                i--;
            }

            for (int u = i; u > 0; u--)
            {
                if (u > 0)
                {
                    array[u] = array[u - 1];
                }
            }
            array[0] = value;
            return;

        }
        //Method that prints off the contents of the structure
        //O(n)
        public void printAll()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    Console.Out.WriteLine("Index = " + i + " value = null");
                }
                else
                {
                    Console.Out.WriteLine("Index = " + i + " value = " + array[i]);
                }
            }
        }

         
        public /*T*/ void dequeue()  
                                     //Method that removes objects from the structures queue, first in first out
                                     //O(n)
        {
          
            T sample = array[queueFront];
            
            array[queueFront] = default(T);
            for (int i = queueRear; i > 0; i--)
            {
                if (array[i] != null)
                {
                    queueFront = i;
                }
            }
         
        }

        public T pop()
        //Method that pops Objects off the structure's stack, first in last out
        //O(1)
        {
            /*
            T sample = array[queueFront];
            array[queueFront] = default(T);
            for (int i = queueRear; i > 0; i--)
            {
                if (array[i] != null)
                {
                    queueFront = i;
                }
            }
            return sample; */
            T temp = array[stackStart];
            array[stackStart] = default(T);
            stackStart++;
            return temp;
        }

        public void deleteAll()
        //Method that uses a for loop to parse through the arraylist, deleting everything and setting every entry to a default generic type
        //O(n)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = default(T);
            }

        }

        // Just returns the front element O(1)
        public T getFront()
        {
         
            return array[queueFront];
        }
      
        // O(N)
        public void grow(int newsize)
        {
            Array.Resize(ref array, newsize);
        }
    }
}
