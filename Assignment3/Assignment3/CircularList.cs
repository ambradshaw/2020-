using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public class CircularList
    {
        private Node head;
        private Node tail;

        
        public static CircularList Create()
        //Method that creates a new empty linked list
        {
            return new CircularList();
        }
        public void printAllForward()
        //Method that prints out the contents of the list in forward order
        //O(n)
        {
            Node current = head;
            while (current != null && current != tail && current.data !=null)
            {
                Console.WriteLine(current.data.ToString());
                current = current.next;

            }
            current = tail;
            if (current != null && current.data!=null)
            {
                Console.WriteLine(current.data.ToString());
            }
        }

        public void printAllReverse()
        //Method that prints out the contents of the list in reverse order
        {
            Node current = tail;
            Console.WriteLine(current.data.ToString());
            current = current.previous;
            //While loop that traverses the nodes in the list from the tail to the head
            while (current != null && current!=head)
            {

                Console.WriteLine(current.data.ToString());
                current = current.previous;

            }
            current = head;
            Console.WriteLine(current.data);

        }
        public void enqueue(Object data)
        //Method that adds an object to the front of the list
        //O(1)
        {
            if (head == null)
            {
                head = new Node();
                tail = new Node();
                head.data = data;
                head.next = tail;
                head.previous = tail;
                tail.next = head;
                tail.previous = head;

            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                toAdd.next = head;
                head.previous = toAdd;
                toAdd.previous = tail;
                head = toAdd;
                tail.next = head;
            }

        }

        public void push(Object data)
        //Method that adds an object to the front of the list
        //O(1)
        {
            if (head == null)
            {
                head = new Node();
                tail = new Node();
                head.data = data;
                head.next = tail;
                head.previous = tail;
                tail.next = head;
                tail.previous = head;

            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                toAdd.next = head;
                head.previous = toAdd;
                toAdd.previous = tail;
                head = toAdd;
                tail.next = head;
            }
        }

        public Object pop()
            //Method that pops objects off of the lists stack, first in last out
            //O(n)
        {
            if (head != null)
            {
                Node output = head;
                Node current = head.next.next;
                current.previous = head;
                head.data = head.next.data;
                head.next = head.next.next;
                return output.data;
            }
            Node current2 = head;
            while(current2 == null)
            {
                current2 = current2.next;
            }
            Node output2 = current2;
            Node current3 = head.next.next;
            current3.previous = current2;
            current2.data = current2.next.data;
            current2.next = current2.next.next;
            return output2.data;

        }
        public void dequeue()
        {
            //O(n)
            //would be O(1) without the ability to return the object being dequeued
            //Atm this method basically just calls deleteLast, but the lines commented out allow it to return the object being dequeued, I just didn't need that
            //Method that removes objects from the list's queue, in proper queue order, first in first out
            if (tail == null)
            {
                Node current = tail;
                while (current == null)
                {
                    current = current.previous;

                }
                Node output2 = current;
                DeleteLast();
               // return output2.data;
            }
            Node output = tail;
            DeleteLast();
            //return output.data;
        
        }

        public void AddLast(Object data)
        //Method that adds an object to the end of the list 
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = tail;
                head.previous = tail;
                tail.next = head;
                tail.previous = head;


            }
            else if (tail == null)
            {
                tail = new Node();
                tail.data = data;
                head.previous = tail;
                tail.next = head;
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
                tail.next = head;
                head.previous = tail;

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
            while (current != null)
            {
                size++;
                current = current.next;
            }
            //Random number generated between 1 and the size of the list
            int rand = rnd.Next(1, size);

            current = head;
            //A for loop to get current to the randomly chosen spot in the list
            for (int i = 0; i < rand - 1; i++)
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
            if (toAdd.next != null)
            {
                toAdd.next.previous = toAdd;
            }





        }
        public void DeleteLast()
        //Method that sets the last node in the list to null
        {
            /*
             Node current = head;
             while (current.next.next != null)
             {
                 current = current.next;
             }
             current.next.data = null;
             current.next = tail;
             tail.next = head;
             head.previous = tail;
             */

            if (tail.previous == head || head.next == tail)
            {
                tail.data = null;
            }
            else if (tail.data == null)
            {
                head.data = null;
            }
            tail.data = tail.previous.data;
            Node current = tail.previous.previous;
            current.next = tail;
            tail.previous = current;
          
         
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
        //O(n)
        {
            Node current = head;
            while (current.next != tail)
            {
                current = current.next;
                current.previous = null;

            }
            current = null;
            tail = null;

        }
    }
}
