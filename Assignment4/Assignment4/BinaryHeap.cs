﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    //Alan-Michael Bradshaw
    //0643996

    class BinaryHeap<T> : IEnumerable where T : IComparable<T>
    {
        private T[] array;
        private int currentIndex = -1;  // Should probably be changed to a count on your assignment but same idea
        public BinaryHeap(int size)
        {
            array = new T[size];
            currentIndex = 0;
        }
        // Get Item should really be private (needs to be public in the lab for demo purposes)
        public T GetItem(int index)
        {
            return array[index];
        }
        private void SetItem(int index, T value)
        {
            if (index >= array.Length)
                Grow(array.Length * 2);
        
            array[index] = value;

        }
        private void Grow(int newsize)
        {
            Array.Resize(ref array, newsize);
        }

        private int LeftChild(int pos)
        { return 2 * pos + 1; }
        private int RightChild(int pos)
        { return 2 * pos + 2; }
        //iterator so you can see how they work (sort of? It works but it's not really obvious how)
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < array.Length; index++)
            {
                // Yield each element 
                yield return array[index];
            }
        }
        public void AddItem(T value)
        {
            // THis is part of your lab 6
            // you need to make this code actually insert in a tree like fashion, not just this crap
            // SetItem(currentIndex, value);
            // currentIndex++;
            if (array[0] == null)
            {
                SetItem(0, value);

            }

            else
            {
                SetItem(currentIndex, value);
                MoveUp(currentIndex);

            }



            currentIndex++;
            //Insert Logic
            // If the tree is empty, insert at the bottom (it does that already)
            // if not, insert at the end, 
            // From the end you either need to swap to the root, and keep minheapify
            // or, you should probably implement move up
            // for that you run a while loop, check if the current position both isn't the root, and is higher priority than a parent (in this case that probably means it's a lower value)
            // if it is, swap with parent, and keep doing that until it's its in the

           

        } 

       /* public void AddItem(T value)
        {
            int index = currentIndex;


                if (value.CompareTo(array[index]) == -1)
                {
                    if (array[index+1] == null)
                    {
                        SetItem(index+1, value);
                    }
                    else
                    {
                    currentIndex++;
                        AddItem(value);
                    }
                }

                else if (value.CompareTo(array[0]) == 1)
                {
                if (array[index + 2] == null)
                {
                    SetItem(index + 2, value);
                }
                else { 
                currentIndex +=2;
                AddItem(value);
                    }
                }
            

        }
        */

        public void MoveUp(int position)
        {
            //Method that moves a given index's node up in the tree until it reaches the right spot
           T tempVal;
            T temp;
            // given an array index, it should keep moving it up the array until it gets to the right spot

            while (position != 0 && array[position].CompareTo(array[(position - 1) / 2]) > 1)
            {

                tempVal = array[(position - 1) / 2];
                //For some god-forsaken reason it breaks without both of these redudant lines
                temp = array[(position - 1) / 2];
                array[(position - 1) / 2] = array[position];
                array[position] = temp;
                position = (position - 1) / 2;
            }

        }

        //ExtractRoot (which is the same as extract min in our case)
        public T ExtractHead()
        {
            // check to make sure the heap isn't empty, if it is, return a 'null' or at least, default object
            if (currentIndex <= 0) // change to count in assignment if you use that
                return default(T);
            // this should get the head
            T head = array[0];
            //then in the lab you need to implement this part yourself
            //array[0] needs to get some value (most likely it will be array[0] = array[Count-1]
            // then remove the data at [count-1], and make sure you don't try and use that data later (remember you can do array[x] = default(T))
            //then Minheapify the array

            return head;

        }
        //
        public void Swap(int position1, int position2)
        {
            T first = array[position1];
            array[position1] = array[position2];
            array[position2] = first;
       
        }
        //heapify should heapify the subtree for the element i that is the root of a subtree

        public void MoveDown(int position)
        {

            // I have no idea why I have this blob of commented code here, I'm sure it it did or does something, and I don't have time to look into it so I'll just leave it here
            //     public void MoveDown(int root)
            //{
            //    // while the root has at least one child
            //    while (LeftChild(root) < count)
            //    {
            //        // root*2+1 points to the left child
            //        int child = LeftChild(root);
            //        // take the highest of the left or right child
            //        if ((child + 1) < count && (array[child].CompareTo(array[child + 1])) > 0)
            //        {
            //            // then point to the right child instead
            //            child = child + 1;
            //        }

            //        // out of max-heap order
            //        // swap the child with root if child is greater
            //        if ((array[root].CompareTo(array[child])) > 0)
            //        {
            //            T tmp = array[root];
            //            array[root] = array[child];
            //            array[child] = tmp;

            //            // return the swapped root to test against
            //            //  it's new children
            //            root = child;
            //        }
            //        else {
            //            return;
            //        }
            //    }
            //}
            int root = position;
            // while the root has at least one child
            while ((2 * root + 1) <= currentIndex)
            {
                // root*2+1 points to the left child
                int child = 2 * root + 1;
                // take the highest of the left or right child
                if ((child + 1) <= currentIndex && (array[child].CompareTo(array[child + 1])) > 0) // <0 max heap > 0 minheap
                {
                    // then point to the right child instead
                    child = child + 1;
                }

                // out of max-heap order
                // swap the child with root if child is less than (
                if ((array[root].CompareTo(array[child])) > 0) //>0 for minheap < 0 maxheap
                {
                    T tmp = array[root];
                    array[root] = array[child];
                    array[child] = tmp;

                    // return the swapped root to test against
                    //  it's new children
                    root = child;
                }
                else
                {
                    return;
                }
            }
        }

        public void buildMinHeap()
        {
            int midPoint = array.Length / 2;
            for (int indexsOfLeaves = midPoint; indexsOfLeaves >= 0; indexsOfLeaves--)
            {
                MinHeapify(indexsOfLeaves);
            }
        }

        //MinHeapify Should be complete but it might have bugs (sorry, these things are hard to test)
        public void MinHeapify(int position)
        {
            int lchild = LeftChild(position);
            int rchild = RightChild(position);
            int largest = 0; // unused was for a max heap which is how this lab used to be.  
            int smallest = position;
            //I'm not 100% sure these if statements are right (sorry)
            // https://www.geeksforgeeks.org/binary-heap/  has an alternative implmentation using "smallest" rather than "largest"
            // https://stackoverflow.com/questions/15493056/min-heapify-method-min-heap-algorithm?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa  has the same sort of question in Java

            if (currentIndex > lchild && (array[lchild].CompareTo(array[smallest])) < 0)  //note that I'm using currentIndex as the heap size which is a bad naming convention
            {
                smallest = lchild;
            }

            if (currentIndex > rchild && (array[rchild].CompareTo(array[smallest])) < 0) //note that I'm using currentIndex as the heap size which is a bad naming convention
            {
                smallest = rchild;
            }
            if (smallest != position)
            {
                Swap(position, smallest);
                MinHeapify(smallest);
            }

        }
        //This is probably what you're looking for Naz
        public void HeapSort()
            //Method that sorts the binary heap into correct min-heap order
        {
            // This one is for your assignments
            //The method builds the heap 
            int heapsize = array.Length - 1;
            buildMinHeap();
            //The method loops through each element in the heap, swapping it with the first element then mineheapify-ing the
            //index at i
            for(int i=0; i<heapsize; i++)
            {
                Swap(0, i);
                 
                // MoveUp(0); 
                MinHeapify(i);
            }

           


        }

    }
}