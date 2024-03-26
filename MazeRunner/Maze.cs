using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    public class Maze
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public Maze(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);   // returns the length of the first dimension of the array  - 10
            Cols = Grid.GetLength(1);   // returns the length of the second dimension of the array - 10
        }

        // Draw the Grid
        public void Draw()
        {
            for(int i=0; i<Rows; i++)
            {
                for(int j=0; j<Cols; j++)
                {
                    string element = Grid[i, j];
                    Console.SetCursorPosition(j, i);
                    Console.Write(element);
                }
            }
        }

        // Checking if Walkable
        public bool isWalkable(int j, int i)
        {
            // Boundaries
            if (j < 0 || i < 0 || j >= Cols || i >= Rows)
            {
                return false;
            }

            // Walkable
            return (Grid[i, j] == " " || Grid[i, j] == "X");

        }

        public string ElementPosition(int j, int i)
        {
            return Grid[i, j];
        }
    }
}
