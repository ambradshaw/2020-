using System;

namespace Assignment3Question2
{
    class Program
        //Driver class for the hashtable program
        //The program adds the conents of firstArray to the hashtable, then searches for an entry matching a specified string
    {
        static void Main(string[] args)
        {
            HashTable table = new HashTable();
            //Contains several elements designed to collide
         String[] firstArray = new String[15] { "one", "two", "a", "no", "four", "three", "asdfgd", "asdfggh", "asdrtyut", "dfghgfdfg", "asdfretrgd", "cvbgdsrgdsf", "asdsssssssss", "qwertrertytre", "vvvvvvvvvvvvvv" };
            for(int i=0; i<firstArray.Length-1; i++)
            {
                table.addItem(firstArray[i]);
                
            }

            table.find("asdrtyut");

        Console.ReadLine();
        }

      
    }


}
