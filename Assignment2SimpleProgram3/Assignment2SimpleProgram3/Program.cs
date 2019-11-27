using System;

namespace Assignment2SimpleProgram3
{
    /*
     * Program that prints every continuous multiple entry subarray within an array that has a total sum of less than the value of K
     */
    class Program
    {
        static void Main(string[] args)
        {

            int K = 10;

            int[] array = new int[] {1,2,3,4,5,6,7,8,9,10};

            //Outer loop that loops through every element in the array
            for(int i = 0; i<array.Length; i++)
            {
                //integer that counts how many times this loop iteration has had a sum less than K
                int timeCount = 0;
                //The value of sum is set to the value of array index i
                int sum = array[i];
                //The output string to be printed is set to include the value of array index i
                String output = "{" + array[i] + ",";
                //Inner loop that parses through every element in the array after the element being parsed by the outer loop
                    for (int u = i + 1; u < array.Length; u++)
                    {
                    //The value of array index u is added to the sum variable
                        sum += array[u];
                    //If the new sum total is less than the value of K, the value of array index u is added to the current output string
                        if (sum < K)
                        {
                            timeCount++;
                            output += array[u] + ",";

                        }
                        //else statement for if the current output string can no longer be expanded without the sum exceeding or equaling the value of K 
                        else
                        {
                        //Only prints if this is not the loops first time failing, this prevents single element subarrays from printing
                            if (timeCount > 0)
                            {
                                Console.Out.WriteLine(output + "}");
                            }
                            //break statement that exits the inner for loop, moving on to the next set of possible subarrays
                            break;
                        }
                    }
                
            }

            Console.ReadLine();
        }
    }
}
