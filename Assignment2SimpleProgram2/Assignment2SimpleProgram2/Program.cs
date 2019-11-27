using System;
/*
 * Simple program that returns the true or false depending on whether or not any 2 elements in an array add
 * up to the value of integer x. The program has 2 methods for doing this, one for unsorted arrays and one for sorted arrays.
 */

namespace Assignment2SimpleProgram2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 39;
            int[] unsortedArray = new int[] { 20, 3, 6, 42, 1000, 9, 0 , 1, 21, 76};
            int[] sortedArray = new int[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10};

            if (unsortedArrayFunction(unsortedArray, x) == true)
            {
                Console.Out.WriteLine("Unsorted True");
            }
            else
            {
                Console.Out.WriteLine("Unsorted False");
            }

            if (sortedArrayFunction(sortedArray, x) == true)
            {
                Console.Out.WriteLine("sorted True");
            }
            else
            {
                Console.Out.WriteLine("sorted False");
            }

            Console.ReadLine();
        }
//Function for unsorted arrays
        public static Boolean unsortedArrayFunction(int[] arr, int x)
        {
            //Function checks each value in the array with every value after it in search of a sum that equals the value of x
            //Outer for loop
            for(int i = 0; i < arr.Length; i++)
            {
                //inner for loop
                for(int j = i; j<arr.Length; j++)
                {
                    if(arr[i] + arr[j] == x)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static Boolean sortedArrayFunction(int[] arr, int x)
            //Function for sorted arrays
            /*Key difference from unsorted function is that this method will return false if a
             * given value is larger or smaller (depending on sort order) than half the value of x,
             * indicating that a matching sum is impossible with any of the remaining values*/
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    //If statement that triggers if the array is sorted in ascending order
                    if (arr[j] < arr[arr.Length-1]){
                        //If statement that returns true if the array values at indexes i and j add up to x
                if (arr[i] + arr[j] == x)
                {
                    return true;
                }
                //If statement that returns false if the value at array index j is greater than half the value of x
                //Because this only executes if the array is sorted in ascending order, if this triggers it means that none of the following values in the array will add up to x
                else if (arr[j] > x/2)
                {
                    return false;
                }
            }
                    //If statement that triggers if the array is sorted in descending order
                   else if(arr[j] > arr[arr.Length-1])
                    {
                        //if statement that triggers if the values at array indexes i and j add up to x
                        if (arr[i] + arr[j] == x)
                        {
                            return true;
                        }
                        //if statement that returns false if the value at array index j is less than half the value of x
                        //Because the array is sorted in descending order if a given vale is less than half the value of x then any number following it won't be able to add up to x
                        else if (arr[j] < x / 2)
                        {
                            return false;
                        }
                    }
                    //else statement meant to trigger if the array consists largely of duplicate values, returns true if the values at array indexes i and j add up to x
                    else
                    {
                        if (arr[i] + arr[j] == x)
                        {
                            return true;
                        }
                    }
        }
            }
            return false;
        }
    }
}

