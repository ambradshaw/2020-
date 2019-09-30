using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    //Class that manages and creates Cell objects
    //Cell objects make up the contents of the array found in grid objects
    class Cell
    {
        private int ID;
        private int width = 10;
        private int height = 10;
        private Position position;
        //List of objects stored on each cell's position
       public List<MobileObject> cellObjectList = new List<MobileObject>();

        //Cell constructor
        public Cell(int iD, int xCoord, int yCoord)
        {
            ID = iD;
            position = new Position(xCoord, yCoord);
        }
        //Getters and setters
        public int ID1 { get => ID; set => ID = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Position Position { get => position; set => position = value; }
    }
}
