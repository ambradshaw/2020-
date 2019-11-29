using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public class GenericArray<T>
    {
        private T[] array;
        private int currentIndex = 0;
        private int queueStart = 0;
        private int queueEnd = -1;
        private int stackStart = 0;

        public int CurrentIndex { get => currentIndex; set => currentIndex = value; }

        public GenericArray(int size)
        {
            array = new T[size + 1];
        }

        public static GenericArray<T> Create(int size)
        //Method that takes in a size integer and creates and returns an empty arraylist of that size
        {
            GenericArray<T> newList;
            newList = new GenericArray<T>(10);
            return newList;
        }

        //So generic can't be compared with normal operators like < and > fine, okay, makes sense
        // I wanted to sort by name, or ID or something, but you can't do that in the GenericArray class because of course
        //A generic class can't know that it's going to contain MobileObject objects
        //The actual sorting algorithm works fine but that's hardly impressive, I just can't find any conceivable way to compare these 
        public void Sort()
        {
            T temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int u = i + 1; u < array.Length; u++)
                {
                    //if (array[i] > array[u])
                    {
                        temp = array[i];
                        array[i] = array[u];
                        array[u] = temp;
                    }
                }
            }
        }




        public T getItem(int index)
        {
            return array[index];
        }
        //Enqueue method that adds objects to the front of the structures queue
        //O(n^2)
        public void enqueue(T obj)
        {
            queueEnd++;
            if (queueEnd > (array.Length - 1))
            {
                Grow();
            }
            T temp = array[0];
            T temp2 = array[0];
            for (int i = 1; i < array.Length-1; i++)
            {
                temp2 = array[i];
                array[i] = temp;
                temp = temp2;

            }
            array[queueStart] = obj;
         
        }
        //push method that adds objects to the top of the structures stack
        //O(n^5)
        public void push(T obj)

        {
            //   Insert(0, obj);
            if (array[queueStart] == null)
            {
                array[queueStart] = obj;
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
                array[0] = obj;
                return;
            }
            Grow();
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
            array[0] = obj;
            return;
        }
        public T pop()
            //Method that pops Objects off the structure's stack, first in last out
            //O(1)
        {
            T temp = array[stackStart];
            array[stackStart] = default(T);
            stackStart++;
            return temp;
        }

        public /*T*/ void dequeue()
            //Method that removes objects from the structures queue, first in first out
            //O(1)
        {
          //  T temp = array[queueEnd];
            array[queueEnd] = default(T);
            queueEnd--;
            //return temp;

             
        }

        public void setItem(int index, T value)
        {
            if (index >= array.Length)
            {
                Grow();
            }

            array[index] = value;
        }


        public void Grow()
        {
            //Method that grows the array by replacing it with a new one doubled in size that contains all the same elements
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length - 1; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        public void Append(T value)
        //Method that takes in a value and sets the value of the array at the current index to the value passed to it, before increasing the current index value by 1
        {
            array[currentIndex] = value;
            currentIndex++;
        }

        public void printAllForward()
        //Method that loops through the array with a for loop, adding each element to a string and printing it off 
        //O(n)
        {
            string arrString = "";
            for (int i = 0; i < array.Length - 1; i++)
            {
                arrString = arrString + (getItem(i) + "\n");
            }
            Console.Out.WriteLine(arrString);
        }
        public void printAllReverse()
        //Method that loops backwards through the array with a for loop, adding each element to a string and printing it off 
        {
            string arrString = "";
            for (int i = array.Length - 1; i > 0; i--)
            {
                arrString = arrString + (getItem(i));
            }
            Console.Out.WriteLine(arrString);
        }

        public bool Find(T value)
        {
            bool flag = false;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].Equals(value))
                {
                    flag = true;
                }
            }
            return flag;
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

        public void deleteLast()
        {
            //Method that deletes the last element by deleting the entry at the index before the current index, which is always the last element added (by appending) 
            setItem(currentIndex - 1, default(T));

        }

        //Method that inserts an object at a given position
        private void Insert(int position, T value)
        {
            int freeSlots = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == null)
                {
                    freeSlots++;
                }
            }
            if (freeSlots == 0)
            {
                Grow();
            }
            for (int i = array.Length - (1 + freeSlots); i > position; i--)
            {
                array[i + 1] = array[i];
            }

            array[position] = value;
        }
    }
}
