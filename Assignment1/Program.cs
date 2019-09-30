using System;
using System.Collections.Generic;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)


        {
           
            
            Random rnd = new Random();
            //integers used to increment ID numbers as objects are created
            int incrementID = 1;
            int incrementInt = 0;

            //3 test MobileObjects of each type are created with hardcoded values
            NPC npc1 = new NPC("alan", 1, 1, 1, 1, 1, 1);
            NPC npc2 = new NPC("Jim", 2, 2, 2, 2, 2, 16);
            NPC npc3 = new NPC("Bob", 3, 3, 3, 3, 3,33);
            Vehicle vehicle1 = new Vehicle("Car", 4, 4, 4, 4, 4, 4);
            Vehicle vehicle2 = new Vehicle("Bike", 5, 2, 2, 2, 1, 2);
            Vehicle vehicle3 = new Vehicle("ATV", 6, 3, 3, 3, 30, 4);
    
            //Grid object is created and the array of cells within it is populated with cell objects
            Grid cellGrid = new Grid();
            for (int i = 0; i < cellGrid.grid.GetLength(0); i++) 
            {
                for (int u = 0; u < cellGrid.grid.GetLength(0); u++)
                {
                    cellGrid.grid[i, u] = new Cell(incrementID, i, u);
                    incrementID++;
                }
            }

            //NPC and Vehicle objects are assigned CellID's matching the ID numbers of the cells they're on

            npc1.PositionCell = cellGrid.grid[((int)npc1.Position.X), (int)npc1.Position.Y].ID1;
            npc2.PositionCell = cellGrid.grid[((int)npc2.Position.X), (int)npc2.Position.Y].ID1;
            npc3.PositionCell = cellGrid.grid[((int)npc3.Position.X), (int)npc3.Position.Y].ID1;
            vehicle1.PositionCell = cellGrid.grid[((int)vehicle1.Position.X), (int)vehicle1.Position.Y].ID1;
            vehicle2.PositionCell = cellGrid.grid[((int)vehicle2.Position.X), (int)vehicle2.Position.Y].ID1;
            vehicle3.PositionCell = cellGrid.grid[((int)vehicle3.Position.X), (int)vehicle3.Position.Y].ID1;

            //An array and a list of MobileObjects are created
            MobileObject[] objectArray = new MobileObject[7];
            List <MobileObject> objectList = new List <MobileObject>();
            //The list of mobile objects is populated with the NPC and Vehicle objects created earlier
            objectList.Add(npc1);
            objectList.Add(npc2);
            objectList.Add(npc3);
            objectList.Add(vehicle1);
            objectList.Add(vehicle2);
            objectList.Add(vehicle3);
           
          
            
               //Every object in the list of objects is added to the array of objects and printed using a method in all MobileObjects
            foreach (MobileObject element in objectList)
            {
                objectArray[incrementInt] = element;
                if (incrementID > objectArray.Length)
                {
                    incrementInt++;
                }
                for(int i = 0; i < cellGrid.grid.GetLength(0); i++)
                {
                    for (int u = 0; u < cellGrid.grid.GetLength(0); u++)
                    {
                        
                        if(element.Position.X == cellGrid.grid[i, u].Position.X && element.Position.Y == cellGrid.grid[i, u].Position.Y)
                        {
                            cellGrid.grid[i, u].cellObjectList.Add(element);
                        }
                    }
                }
                element.printObject();
            }

            //The user creates an object
            int choiceInt = 0;
            while (choiceInt != 1 && choiceInt != 2)
            {
                //The user is prompted to enter a number corresponding to the type of object they wish to create
                Console.Out.WriteLine("Enter 1 to create an NPC object, enter 2 to create a vehicle object: ");
                choiceInt = Convert.ToInt32(Console.ReadLine());
                if (choiceInt == 1)
                {
                    float objTorsoLength = 0;
                    float objHeadHeight = 0;
                    float objLegLength = 0;
                    float objArmLength = 0;
                    float objMass = 0;
                    //The user is prompted to enter the details of the object being created
                    Console.Out.WriteLine("Please enter the name of your object: ");
                    String objName = Console.ReadLine();
                    Console.Out.WriteLine("Please enter the integer ID of your object: ");
                    int objID = Convert.ToInt32(Console.ReadLine());
                    //When entering values that must be above 0 the program will prompt the user for the value until a valid input is given
                    while (objTorsoLength <= 0)
                    {
                        Console.Out.WriteLine("Please enter the torso length of your object (Must be greater than 0): ");
                        objTorsoLength = float.Parse(Console.ReadLine());
                    }
                    while (objHeadHeight <= 0)
                    {
                        Console.Out.WriteLine("Please enter the head height of your object (Must be greater than 0): ");
                        objHeadHeight = float.Parse(Console.ReadLine());
                    }
                    while (objLegLength <= 0)
                    {
                        Console.Out.WriteLine("Please enter the leg length of your object (Must be greater than 0): ");
                        objLegLength = float.Parse(Console.ReadLine());
                    }
                    while (objArmLength <= 0)
                    {
                        Console.Out.WriteLine("Please enter the arm length of your object (Must be greater than 0): ");
                        objArmLength = float.Parse(Console.ReadLine());
                    }
                    while (objMass <= 0)
                    {
                        Console.Out.WriteLine("Please enter the mass of your object (Must be greater than 0): ");
                        objMass = float.Parse(Console.ReadLine());
                    }
                    //An NPC object is created using the values entered by the user
                    NPC userNPC = new NPC(objName, objID, objTorsoLength, objHeadHeight, objLegLength, objArmLength, objMass);

                    foreach (MobileObject element in objectList)
                    {
                        //If the object created shares the same position as an existing object, the Z value of the new object is increased by 1
                        if (userNPC.Position.X == element.Position.X && userNPC.Position.Y == element.Position.Y && userNPC.Position.Z == element.Position.Z)
                        {
                            userNPC.Position.Z++;
                        }
                        //The object is added to the list of objects of the cell it's on
                        for (int i = 0; i < cellGrid.grid.GetLength(0); i++)
                        {
                            for (int u = 0; u < cellGrid.grid.GetLength(0); u++)
                            {
                                if (element.Position.X == cellGrid.grid[i, u].Position.X && element.Position.Y == cellGrid.grid[i, u].Position.Y)
                                {
                                    cellGrid.grid[i, u].cellObjectList.Add(element);
                                }
                            }
                        }
                    }
                    //The created NPC is added to the list of objects
                    objectList.Add(userNPC);
                    objectArray[incrementInt] = userNPC;
                    Console.Out.WriteLine("NPC object created sucessfully.");
                }
                else if (choiceInt == 2)
                {

                    float vehicleLength = 0;
                    float vehicleHeight = 0;
                    float vehicleWidth = 0;
                    float vehicleMass = 0;
                    int numWheels = 0;

                    Console.Out.WriteLine("Please enter the name of your object: ");
                    String vehicleName = Console.ReadLine();
                    Console.Out.WriteLine("Please enter the integer ID of your object: ");
                    int vehicleID = Convert.ToInt32(Console.ReadLine());
                    //When entering values that must be above 0 the program will prompt the user for the value until a valid input is given
                    while (vehicleLength <= 0)
                    {
                        Console.Out.WriteLine("Please enter the length of your object (Must be greater than 0): ");
                        vehicleLength = float.Parse(Console.ReadLine());
                    }

                    while (vehicleHeight <= 0)
                    {
                        Console.Out.WriteLine("Please enter the height of your object (Must be greater than 0): ");
                        vehicleHeight = float.Parse(Console.ReadLine());
                    }

                    while (vehicleWidth <= 0)
                    {
                        Console.Out.WriteLine("Please enter the width of your object (Must be greater than 0): ");
                        vehicleWidth = float.Parse(Console.ReadLine());
                    }
                    while (vehicleMass <= 0)
                    {
                        Console.Out.WriteLine("Please enter the mass of your object (Must be greater than 0): ");
                        vehicleMass = float.Parse(Console.ReadLine());
                    }
                    while (numWheels <= 0)
                    {
                        Console.Out.WriteLine("Please enter the number of wheels on your object (Must be greater than 0): ");
                        numWheels = Convert.ToInt32(Console.ReadLine());
                    }
                    //A new Vehicle object is created using the values entered by the user
                    Vehicle userVehicle = new Vehicle(vehicleName, vehicleID, vehicleLength, vehicleHeight, vehicleWidth, vehicleMass, numWheels);
                    foreach (MobileObject element in objectList)
                    {

                        //If the object created shares the same position as an existing object, the Z value of the new object is increased by 1

                        if (userVehicle.Position.X == element.Position.X && userVehicle.Position.Y == element.Position.Y && userVehicle.Position.Z == element.Position.Z)
                        {
                            userVehicle.Position.Z++;
                        }
                        //The object is added to the list of objects of the cell it's on
                        for (int i = 0; i < cellGrid.grid.GetLength(0); i++)
                        {
                            for (int u = 0; u < cellGrid.grid.GetLength(0); u++)
                            {
                                if (element.Position.X == cellGrid.grid[i, u].Position.X && element.Position.Y == cellGrid.grid[i, u].Position.Y)
                                {
                                    cellGrid.grid[i, u].cellObjectList.Add(element);
                                }
                            }
                        }
                    }
                    //The created vehicle object is added to the list of Mobile Objects
                    objectList.Add(userVehicle);
                    objectArray[incrementInt] = userVehicle;
                    Console.Out.WriteLine("Vehicle object created sucessfully.");
                }
                else
                {
                    Console.Out.WriteLine("Error: Invalid Input.");
                }

            }

            //The user is prompted to enter the ID of an object they wish to move, and the values they would like to move it by
            Console.Out.WriteLine("Enter the object ID of the object you want to move: ");
            int moveID = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("Enter the X value that you would like to move the object by: ");
            int moveX = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("Enter the Y value that you would like to move the object by: ");
            int moveY = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("Enter the Z value that you would like to move the object by: ");
            int moveZ = Convert.ToInt32(Console.ReadLine());

            //boolean that signals whether or not an object has been moved
            bool moveFlag = false;
            //foreach statement that parses through the list of Mobile Objects looking for one with an ID number matching the user's input
            foreach (MobileObject element in objectList)
            {
                //If a matching ID is found the corresponding object is moved using a method built into all Mobile Objects
                if (element.ID1 == moveID)
                {
                    //The element is removed from it's former cell's list of objects
                    for (int i = 0; i < cellGrid.grid.GetLength(0); i++)
                    {
                        for (int u = 0; u < cellGrid.grid.GetLength(0); u++)
                        {
                            if (element.Position.X == cellGrid.grid[i, u].Position.X && element.Position.Y == cellGrid.grid[i, u].Position.Y)
                            {
                                cellGrid.grid[i, u].cellObjectList.Remove(element);
                            }
                        }
                    }

                    element.move(moveX, moveY, moveZ);
                    //The element is added to it's new cell's list of objects
                    for (int i = 0; i < cellGrid.grid.GetLength(0); i++)
                    {
                        for (int u = 0; u < cellGrid.grid.GetLength(0); u++)
                        {
                            if (element.Position.X == cellGrid.grid[i, u].Position.X && element.Position.Y == cellGrid.grid[i, u].Position.Y)
                            {
                                cellGrid.grid[i, u].cellObjectList.Add(element);
                            }
                        }
                    }
                    element.printObject();
                    moveFlag = true;
                }
                
            }
            if(moveFlag == true)
            {
                Console.Out.WriteLine("Object moved sucessfully.");
            }
            else
            {
                Console.Out.WriteLine("The object ID number entered does not match any known objects.");
            }

            foreach (MobileObject element in objectList)
            {
                  
               
                element.printObject();
            }
            //Print out the contents of the grid
            cellGrid.printGrid();
            
            //Initialize the array that will hold the randomly sorted results of the mini challenge
            MobileObject[] randomizedArray = new MobileObject[7];



            //Copy the contents of objectArray to randomizedArray randomly without duplicates by creating an array of integers(0-6), randomizing it and using those as index values
            int[] numArray = new int[7] {0,1,2,3,4,5,6 };
        
            //Contents of numArray are randomized using Fisher-Yates algorithm
             for (int i = 0; i < numArray.Length - 1; i++)
             {
                 int u = rnd.Next(i, numArray.Length);
                 int temp = numArray[i];
                 numArray[i] = numArray[u];
                 numArray[u] = temp;
             }
             

             //Contents of objectArray are transfered to randomizedArray using the randomly placed contents of numArray as indices

            for (int i = 0; i < numArray.GetLength(0); i++)
            {
                randomizedArray[numArray[i]] = objectArray[i];
            }

            Console.Out.WriteLine("Non randomized array: ");
            for (int i = 0; i < objectArray.Length; i++)
                {
                objectArray[i].printObject();
                }

            Console.Out.WriteLine("Randomized array: ");
            for (int i = 0; i < randomizedArray.Length; i++)
            {
                randomizedArray[i].printObject();
            }
            

            Console.ReadLine();
        }
       
        
         
        

        
    }
}
