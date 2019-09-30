using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    //Abstract class that acts as a parent template for the Vehicle and NPC classes
    public abstract class MobileObject
    {
        private String name;
        private int ID;
        private Position position;
        private int positionCell;

        //Constructor for Mobile Objects
        public MobileObject(string name, int iD)
        {
            this.Name = name;
            ID1 = iD;
            this.Position = new Position();
           
        }
        //Getters and setters for mobile object properties
        public string Name { get => name; set => name = value; }
        public int ID1 { get => ID; set => ID = value; }
        public int PositionCell { get => positionCell; set => positionCell = value; }
        internal Position Position { get => position; set => position = value; }

        //Method that moves an object by adding x, y and z values passed to it to the exisiting X, Y and Z values of the object's position
        public void move(int dx, int dy, int dz)
        {
            position.X = dx + position.X;
            position.Y = dy + position.Y;
            position.Z = dz + position.Z;
        }
        //Abstract print method present in all Mobile Object classes
        public abstract void printObject();
       
    }
}
