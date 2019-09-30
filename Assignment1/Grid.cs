using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    //Class that creates and manages grid objects
    //Grid objects contain a 2d array consisting of cells which functions as the actual 'Grid' of the program
    class Grid
    {
        //Array of one of 2 sizes that stores cell objects
       //public Cell[,] grid = new Cell[10, 10];
       public Cell[,] grid = new Cell[16, 16];

            //Grid constructor
        public Grid()
        {
           // grid = new Cell[10, 10];
            grid = new Cell[16, 16];

        }

        
        //Method that is passed a position object and returns the ID of a cell located at that position's coordinates
        public int GetCellID(Position position) 
        {
            int x = (int)position.X;
            int y = (int)position.Y;

            return grid[x, y].ID1;
        }
        //Method that prints out the ID of each cell in the grid's array, along with the number of objects on each cell
        public void printGrid()
        {
            for(int i =0; i < grid.GetLength(0); i++)
            {
                for (int u = 0; u < grid.GetLength(0); u++)
                {
                    //The List of objects on the cell is sorted by the Z coordinate of the position of each object in the list before being printed
                    grid[i, u].cellObjectList.Sort((x, y) => x.Position.Z.CompareTo(y.Position.Z));
                 
                    Console.Out.WriteLine("Cell ID: " + grid[i, u].ID1 + " Number of objects on cell: " + grid[i, u].cellObjectList.Count);
                  }
            }
        }
    }
}
