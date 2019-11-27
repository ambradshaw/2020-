using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class GenericArray<T>
    {
        private T[] array;
        private int currentIndex = 0;

        public int CurrentIndex { get => currentIndex; set => currentIndex = value; }

        public GenericArray(int size)
        {
            array = new T[size + 1];
        }

        public static GenericArray<T> Create (int size)
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
        }

        public void Append(T value)
            //Method that takes in a value and sets the value of the array at the current index to the value passed to it, before increasing the current index value by 1
        {
            array[currentIndex] = value;
            currentIndex++;
        }

        public void printAllForward()
        //Method that loops through the array with a for loop, adding each element to a string and printing it off 
        {
            string arrString = "";
            for (int i = 0; i < array.Length - 1; i++)
            {
                arrString = arrString + (getItem(i));
            }
            Console.Out.WriteLine(arrString);
        }
        public void printAllReverse()
            //Method that loops backwards through the array with a for loop, adding each element to a string and printing it off 
        {
            string arrString = "";
            for (int i = array.Length-1; i > 0; i--)
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
        {
          
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = default(T);
            }
           
        }

        public void deleteLast()
        {
            //Method that deletes the last element by deleting the entry at the index before the current index, which is always the last element added (by appending) 
            setItem(currentIndex-1, default(T));

        }

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
