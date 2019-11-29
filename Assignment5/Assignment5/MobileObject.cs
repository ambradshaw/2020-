using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    //Abstract class that acts as a parent template for the Vehicle and NPC classes
    public abstract class MobileObject : IComparable<MobileObject>  //<T> : IEnumerable where T : IComparable<T>
    {
        private String name;
        private int ID;
        protected int x;
        protected int y;
        protected int z;
        //distance from origin
        protected int DFO;
        Random rnd = new Random();


        //Constructor for Mobile Objects
        public MobileObject(string name, int iD)
        {
            this.Name = name;
            ID1 = iD;
            x = rnd.Next(1, 500);
            y = rnd.Next(1, 500);
            z = rnd.Next(1, 500);
            DFO = Convert.ToInt32(Math.Sqrt((x * x) + (y * y) + (z * z)));

        }
        //Getters and setters for mobile object properties
        public string Name { get => name; set => name = value; }
        public int ID1 { get => ID; set => ID = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
        public int Dfo { get => DFO; set => DFO = value; }


        //Abstract print method present in all Mobile Object classes
        public abstract void printObject();

        public int CompareTo(MobileObject obj)
        {
            if (obj != null)
            {
                return DFO.CompareTo(obj.DFO);
            }
            else
            {
                return -1;
            }
        }

         public IEnumerator GetEnumerator()
         {
             return ((IEnumerable)DFO.ToString()).GetEnumerator();
         }
         
    }
}