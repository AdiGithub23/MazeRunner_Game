using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    public class MazeRunner
    {
        public int X {get; set;} 
        public int Y { get; set;}

        public string Thomas;               // Designator
        public ConsoleColor ThomasColor;    // Designator Color

        public MazeRunner(int initX, int initY)
        {
            X = initX;
            Y = initY;
            Thomas = "0";
            ThomasColor = ConsoleColor.DarkCyan;
        }

        public void Draw()
        {
            Console.ForegroundColor = ThomasColor;
            Console.SetCursorPosition(Y,X);
            Console.Write(Thomas);
        }

        //public void MoveThomasUp()
        //{
        //    Y = Y - 1;
        //}
        //public void MoveThomasDown()
        //{
        //    Y = Y + 1;
        //}
        //public void MoveThomasLeft()
        //{
        //    X = X - 1;
        //}
        //public void MoveThomasRight()
        //{
        //    X = X + 1;
        //}

        public void MoveThomasUp()
        {
            X = X - 1; // Move up one row
        }

        public void MoveThomasDown()
        {
            X = X + 1; // Move down one row
        }

        public void MoveThomasLeft()
        {
            Y = Y - 1; // Move left one column
        }

        public void MoveThomasRight()
        {
            Y = Y + 1; // Move right one column
        }

    }
}
