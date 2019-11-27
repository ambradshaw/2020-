using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Node
    {
        public Node next;
        public Node previous;
        public Object data;
    }
    public class LinkedList
    {
        private Node head;
        private Node tail;

        public static LinkedList Create()
            //Method that creates a new empty linked list
        {
            return new LinkedList();
        }
        public void printAllForward()
            //Method that prints out the contents of the list in forward order
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;

            }
            current = tail;
            Console.WriteLine(current.data);
        }

        public void printAllReverse()
        //Method that prints out the contents of the list in reverse order
        {
            Node current = tail;
            Console.WriteLine(current.data);
            //While loop that traverses the nodes in the list from the tail to the head
            while (current != null)
            {
           
                    Console.WriteLine(current.data);
                    current = current.previous;
             
   }
            current = head;
            Console.WriteLine(current.data);

        }
        public void AddFront(Object data)
            //Method that adds an object to the front of the list
        {
            if (head == null)
            {
                head = new Node();
                tail = new Node();
                head.data = data;
                head.next = null;
                head.previous = null;

            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                toAdd.next = head;
                head.previous = toAdd;
                toAdd.previous = null;
                head = toAdd;
            }




        }

        public void AddLast(Object data)
            //Method that adds an object to the end of the list 
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
                head.previous = null;


            }
            else if(tail == null)
            {
                tail = new Node();
                tail.data = data;
                head.next = tail;
                tail.previous = head;
            }
            else
            {
                Node formerLast = new Node();
                formerLast.data = tail.data;
                formerLast.previous = tail.previous;
                tail.previous.next = formerLast;
                tail.previous = formerLast;
                formerLast.next = tail;
                tail.data = data;

            }

        }

        public void insertAtRandomLocation(Object obj)
            //Method that adds a passed object into the list at a random position
        {
            Random rnd = new Random();
            int size = 0;
            Node current = head;
            Node toAdd = new Node();
            toAdd.data = obj;
            //While loop to get the size of the list
            while(current != null)
            {
                size++;
                    current = current.next;
            }
            //Random number generated between 1 and the size of the list
            int rand = rnd.Next(1, size);

            current = head;
            //A for loop to get current to the randomly chosen spot in the list
            for(int i = 0; i < rand-1; i++)
            {
                current = current.next;
            }

            //The next of the node being added is set to the next of the node that will be infront of it
            toAdd.next = current.next;
            //The next of the node infront of the new node is set to the new node
            current.next = toAdd;
            //The previous of the node being added is set to the node that will be infront of it
            toAdd.previous = current;
            //If the next of the node being added is not null, the previous of that node is set to the node being added
            if(toAdd.next != null)
            {
                toAdd.next.previous = toAdd;
            }
          




        }
        public void deleteLast()
            //Method that sets the last node in the list to null
        {
            Node current = head;
            while (current.next.next != null)
            {
                current = current.next;
            }
            current.next.data = null;
            current.next = null;
        }

        public void deleteFirst()
            //Method that sets the first node in the list to null
        {
            if (head != null)
            {
                Node current = head;
                current.next.previous = null;

            }

        }
        public void deleteAll()
            //Method that sets every node in the list to null
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
                current.previous = null;

            }
            current = null;

        }
    }
}