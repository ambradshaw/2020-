using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    //Abstract class that acts as a parent template for the Vehicle and NPC classes
    public abstract class MobileObject
    {
        private String name;
        private int ID;
     

        //Constructor for Mobile Objects
        public MobileObject(string name, int iD)
        {
            this.Name = name;
            ID1 = iD;
          

        }
        //Getters and setters for mobile object properties
        public string Name { get => name; set => name = value; }
        public int ID1 { get => ID; set => ID = value; }


        //Abstract print method present in all Mobile Object classes
        public abstract void printObject();

    }
}