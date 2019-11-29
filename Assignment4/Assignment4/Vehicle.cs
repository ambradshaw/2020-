using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    //Mobile Object subclass that manages and creates Vehicle objects
    class Vehicle : MobileObject
    {
        private float length;
        private float height;
        private float width;
        private float mass;
        private int numWheels;
        private float boundingVolume;
        Random rnd = new Random();

        //Vehicle Constructor
        public Vehicle(string name, int iD, float length, float height, float width, float mass, int numWheels) : base(name, iD)
        {
            this.length = length;
            if (length <= 0)
            {
                this.length = 0;
            }
            this.height = height;
            if (height <= 0)
            {
                this.height = 0;
            }
            this.width = width;
            if (width <= 0)
            {
                this.width = 0;
            }
            this.mass = mass;
            if (mass <= 0)
            {
                this.mass = 0;
            }
            this.numWheels = numWheels;
            if (numWheels <= 0)
            {
                this.numWheels = 0;
            }
            this.boundingVolume = getBoundingVolume();
            this.Name = name;
            ID1 = iD;
            x = rnd.Next(1, 500);
            y = rnd.Next(1, 500);
            z = rnd.Next(1, 500);
            DFO = Convert.ToInt32(Math.Sqrt((x * x) + (y * y) + (z * z)));
        }

        //Getters and setters for object properties
        public float getLength()
        {
            return this.length;
        }

        public void setLength(float value)
        {
            if (value > 0)
            {
                this.length = value;
            }
            else
            {
                Console.Out.WriteLine("Property must have a value greater than 0, property has been set to 1 by  default");
                this.length = 1;
            }
        }
        public float getHeight()
        {
            return this.height;
        }
        public void setHeight(float value)
        {
            if (value > 0)
            {
                this.height = value;
            }
            else
            {
                Console.Out.WriteLine("Property must have a value greater than 0, property has been set to 1 by  default");
                this.height = 1;
            }
        }

        public float getWidth()
        {
            return this.width;
        }
        public void setWidth(float value)
        {
            if (value > 0)
            {
                this.width = value;
            }
            else
            {
                Console.Out.WriteLine("Property must have a value greater than 0, property has been set to 1 by  default");
                this.width = 1;
            }
        }

        public float getMass()
        {
            return this.mass;
        }
        public void setMass(float value)
        {
            if (value > 0)
            {
                this.mass = value;
            }
            else
            {
                Console.Out.WriteLine("Property must have a value greater than 0, property has been set to 1 by  default");
                this.mass = 1;
            }
        }

        public int getNumWheels()
        {
            return this.numWheels;
        }
        public void setNumWheels(int value)
        {
            if (value > 0)
            {
                this.numWheels = value;
            }
            else
            {
                Console.Out.WriteLine("Property must have a value greater than 0, property has been set to 1 by  default");
                this.numWheels = 1;
            }
        }
        //Print method that overrides parent class method: prints out the information of the Vehicle object in question
        public override void printObject()
        {
            Console.Out.WriteLine("Name: " + Name + " ID: " + ID1 + " Height: " + height + " Length: " + length + " Width: " + width + " Mass: " + mass + " Number of wheels: " + numWheels + " Bounding Volume: " + boundingVolume);
        }
        //Private method that calculates and returns the volume of the vehicle
        private float getBoundingVolume()
        {
            return (length * width * height);
        }
    }
}