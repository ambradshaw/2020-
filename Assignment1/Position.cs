using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    //Class that creates and manages Position objects, which act as storage containers for object and cell coordinates
    class Position
    {
       private float x;
       private float y;
       private float z;

        //Constructor for object positions
        public Position(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        //contructor for cell positions
        public Position(float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.Z = 0;
        }
        //Default contructor that creates a position with random coordinate values
        public Position()
        {
            Random rnd = new Random();
            this.X = rnd.Next(0, 10);
            this.Y = rnd.Next(0, 10);
            this.Z = rnd.Next(0, 10);
        }

        //getters and setters
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
    }
}
