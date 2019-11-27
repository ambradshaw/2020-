using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mobile object instantiations, 5 of each type
            NPC npc1 = new NPC("John", 1, 1, 1, 1, 1, 10);
            NPC npc2 = new NPC("Johnny", 2, 3, 34, 5, 77, 100);
            NPC npc3 = new NPC("not-John", 3, 44, 134, 1, 1, 10);
            NPC npc4 = new NPC("John 2: redemption", 4, 23, 1, 1, 1, 10);
            NPC npc5 = new NPC("John Wick", 5, 1, 1, 3, 25, 20);

            Vehicle vehicle1 = new Vehicle("Car", 6, 6, 6, 6, 666, 4);
            Vehicle vehicle2 = new Vehicle("Really long car", 7, 60, 4, 1, 88, 43);
            Vehicle vehicle3 = new Vehicle("ATV", 8, 6, 6, 4, 666, 4);
            Vehicle vehicle4 = new Vehicle("Slightly less long car", 9, 77, 6, 6, 23, 17);
            Vehicle vehicle5 = new Vehicle("Golf Cart", 10, 6, 6, 11, 1, 4);
            //Both types of lists are created using their respective create methods
            GenericArray<MobileObject> arrayList = GenericArray<MobileObject>.Create(6);

            LinkedList linkedList = LinkedList.Create();
//The NPC and Vehicle Objects created are appended into the arraylist
            arrayList.Append(npc1);
            arrayList.Append(npc2);
            arrayList.Append(npc3);
            arrayList.Append(npc4);
            arrayList.Append(npc5);
            //The arrayList is grown (2x) to accomodate all the objects
            arrayList.Grow();
            arrayList.Append(vehicle1);
            arrayList.Append(vehicle2);
            arrayList.Append(vehicle3);
            arrayList.Append(vehicle4);
            arrayList.Append(vehicle5);
            Console.Out.WriteLine("The arrayList before deleting the last element: ");
            Console.Out.WriteLine("");
            arrayList.printAllForward();
            //The last element of the arraylist is deleted, meaning there should be 5 NPC objects and 4 Vehicle objects left
            arrayList.deleteLast();

//The Linked list is populated with the Mobile Objects created by adding them to the front, the back and at a random location
            linkedList.AddLast(npc1);
            linkedList.AddFront(npc2);
            linkedList.AddLast(npc3);
            linkedList.AddLast(npc5);
            linkedList.AddFront(vehicle1);
            linkedList.AddLast(vehicle2);
            linkedList.AddLast(vehicle3);
            linkedList.AddLast(vehicle4);
            linkedList.AddLast(vehicle5);
            linkedList.insertAtRandomLocation(npc4);
            Console.Out.WriteLine("");
            Console.Out.WriteLine("The linked list before having it's first and last entries deleted: ");
            linkedList.printAllForward();
            //The first and last elements are deleted using the respective methods
            linkedList.deleteFirst();
            linkedList.deleteLast();

            //In total there should be 8 mobile objcts in the list after these method calls

            //Both lists are printed forward
            Console.Out.WriteLine("");
            Console.Out.WriteLine("Printing both lists forward: 10 Mobile objects were added to each, the last element of the arrayList has been deleted and the first and last elements of the linked list have been deleted");
            Console.Out.WriteLine("ArrayList: ");
            arrayList.printAllForward();
            Console.Out.WriteLine("");
            Console.WriteLine("LinkedList: ");
            linkedList.printAllForward();
            Console.Out.WriteLine("");
            //Both lists are printed Backwards
            Console.Out.WriteLine("Printing reverse");
            arrayList.printAllReverse();
            Console.Out.WriteLine("");
            linkedList.printAllReverse();
            Console.Out.WriteLine("");
            //The arraylist has all of its elements deleted and is then printed forward
            Console.Out.WriteLine("Printing forward after deleting all from Arraylist");
            arrayList.deleteAll();
            arrayList.printAllForward();
            Console.Out.WriteLine("TAH-DAH! Nothing.");




            Console.ReadLine();
        }
    }
}
