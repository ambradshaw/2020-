using System;

namespace Assignment2SimpleProgram1
    //Program that finds a local maximum in an array of integers and returns the array index of the local max value
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 0, 7, 5, 15, 7, 8, 9, 10, 3, 8, 13, 15 };
            int[] pArray = new int[] { 1, 0, 7, 5, 15, 7, 8, 8, 8, 9, 8, 13, 15 };

            Console.Out.WriteLine("The local maximum is at index: " + maxFind(array, 0, 12));
            Console.Out.WriteLine("(with plateau) The local maximum is at index: "+ maxFindPlateau(pArray, 0, 12));


            Console.ReadLine();
        }
        //The method uses a binary search variant
         
        public static int maxFind(int[] arr, int start, int end)
        {
            //The value of mid is set to half-way through the array, best with even number index sizes

            int mid = (start + end) / 2;
            //If the middle value is a local max then it is returned
            if (arr[mid] > arr[mid + 1] && arr[mid] > arr[mid - 1])
            {
                return mid;
            }
            //else if the middle value is less than the value to it's left the function calls itself on the left half of the array
            else if (arr[mid] < arr[mid - 1])
            {
                return maxFind(arr, start, mid-1);
            }
            //else if the middle value is less than the value to it's right the function calls itself on the right half of the array
            else if (arr[mid] < arr[mid + 1])
            {
                return maxFind(arr, mid+1, end);
            }

            return 404;

        }
        //The plateau compatible version of the funtion simply changes the 'less than' in the else if statements to 'less than or equal to' 
        public static int maxFindPlateau(int[] arr, int start, int end)
        {
            //The value of mid is set to half-way through the array, best with even number index sizes
            int mid = (start + end) / 2;
            if (arr[mid] > arr[mid + 1] && arr[mid] > arr[mid - 1])
            {
                return mid;
            }
            //else if the middle value is less than or equal to the value to it's left the function calls itself on the left half of the array
            else if (arr[mid] <= arr[mid - 1])
            {
                return maxFind(arr, start, mid - 1);
            }
            //else if the middle value is less than or equal to the value to it's right the function calls itself on the right half of the array
            else if (arr[mid] <= arr[mid + 1])
            {
                return maxFind(arr, mid + 1, end);
            }

            return 404;

        }
    }
}
