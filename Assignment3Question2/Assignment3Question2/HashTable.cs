using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3Question2
    //hashtable class that allows the creation and use of rudimentary hash tables
{
    class HashTable
    {
        private String[] finalArray;

        public HashTable()
            //O(n)
        {
            //Each hash table contains an array of string entries, each stored at an index determined by the hash function
            finalArray = new String[15];
        }


           private void Grow(int index)
        {
            //Method that grows the array by replacing it with a new one doubled in size that contains all the same elements
           String[] newArray = new String[finalArray.Length*2];
            for (int i = 0; i < finalArray.Length - 1; i++)
            {
                newArray[i] = finalArray[i];
            }
        }

        private int HashFunction(String input)
            //Hash function method that takes in a string and returns an integer value equal to the number of characters in the string
        {
            return input.Length;
        }

        public void find(String target)
            //O(n)
        {
            //Method that searches the hash table for a entry matching the string passed to the method
            int index = HashFunction(target);
            //The passed string is run through the hash function and the corresponding array index is checked for a match
            if (finalArray[index] == target)
            {
                Console.Out.WriteLine("Entry: " + target + " found at index: " + index);
            }
            else
            {
                //if no match is found at the intial index then the method uses quadratic probing to search for a match
                int n = 1;
                while(finalArray[index] != target)
                {
                    //The program searches for a match at index+n^2, increasing n by one each time a search does not find a match
                    index += (n * n);
                    n++;
                }
                if (finalArray[index] == target)
                {
                    Console.Out.WriteLine("Entry: " + target + " found at index: " + index);
                }
                else
                {
                    Console.Out.WriteLine("Entry: " + target + " not found");
                }
                }
        }

        public void addItem(String input)
            //O(n)
        {
            //Method that inserts a passed string into the hash table array
            int index = HashFunction(input);
            //If the index returned by the hash function is outside the bounds of the array, the array is grown to accomodate it
            if (index > (finalArray.Length - 1))
            {
                Grow(index);
            }
            if (String.IsNullOrEmpty(finalArray[index]))
            {
            //If the array index returned by the hash funcion is null or empty, the value of that entry is set to the string being inserted
                finalArray[index] = input;
                Console.Out.WriteLine("Input: " + input + " added at index: " + index);
            }
            else
            {
                //If the index returned by the hash function is already filled/occupied, the program uses quadratic probing to find a new empty position for the string being inserted
                int n = 1;
                while (!String.IsNullOrEmpty(finalArray[index]))
                {
                    //The program searches for an empty array entry at index+n^2, increasing n by one each time a empty entry is not found
                    index = index +(n*n);
                    if (index > (finalArray.Length - 1))
                    {
                        //If the index is outside the bounds of the array, the array is grown to accomodate it
                        Grow(index);
                    }
                    n++;
                }
                finalArray[index] = input;
                Console.Out.WriteLine("Input: " + input + " added at index: " + index);
            }
        }
    }
}
