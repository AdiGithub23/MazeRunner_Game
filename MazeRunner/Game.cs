using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MazeRunner
{
    public class Game
    {
        private Maze world_1;
        private MazeRunner currentPlayer;

        public void StartGame()
        {
            // Defining the grid
            //string[,] grid = {
            //    {"=", "=", "=", "=", "=", "=", "=", "=", "=", "="},
            //    {"=", " ", " ", " ", " ", " ", " ", " ", " ", "="},
            //    {"=", " ", "=", "=", "=", "=", "=", "=", " ", "="},
            //    {"=", " ", "=", " ", " ", " ", " ", "=", " ", "="},
            //    {"=", " ", "=", "=", "=", "=", "=", "=", " ", "="},
            //    {"=", " ", " ", " ", " ", " ", " ", "=", " ", "="},
            //    {"=", "=", "=", "=", "=", "=", " ", "=", " ", "="},
            //    {"=", " ", " ", " ", " ", " ", " ", "=", " ", "="},
            //    {"=", " ", "=", "=", "=", "=", "=", "=", " ", "X"},
            //    { "=", "=", "=", "=", "=", "=", "=", "=", "=", "="}
            //};

            string[,] grid = {
                {"=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "="},
                {"=", " ", "=", " ", " ", " ", "=", " ", "=", "=", " ", "=", " ", "=", "=", "=", "=", "=", "=", "="},
                {"=", " ", "=", "=", "=", " ", "=", " ", "=", "=", " ", "=", " ", " ", " ", " ", " ", " ", " ", "="},
                {"=", " ", "=", " ", "=", " ", " ", " ", " ", " ", " ", " ", "=", "=", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", " ", " ", " ", "=", "=", " ", "="},
                {"=", " ", "=", " ", " ", " ", " ", " ", " ", " ", "=", "=", "=", "=", "=", " ", "=", "=", " ", "="},
                {"=", " ", "=", "=", "=", "=", "=", "=", "=", " ", "=", "=", " ", "=", " ", " ", "=", "=", " ", "="},
                {"=", " ", "=", "=", "=", "=", "=", "=", "=", " ", " ", " ", " ", "=", " ", "=", "=", "=", " ", "="},
                {"=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", " ", " ", " ", "=", " ", "="},
                {"=", " ", "=", " ", "=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", " ", "=", " ", "=", " ", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", " ", "=", " ", "=", "=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "0", "0", "0"},
                {"=", "=", "=", " ", "=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", " ", "=", " ", " ", " ", " ", " ", " ", " ", " ", " ", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", " ", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", " ", " ", " ", " ", " ", " ", " ", " ", "=", "=", "=", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", " ", "="},
                {"=", " ", "=", " ", " ", " ", " ", " ", " ", " ", " ", "=", " ", " ", " ", " ", " ", "=", " ", "="},
                {"=", " ", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "="},
                {"=", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "="},
                {"=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "="}
            };



        // Initializing a new Playground
        world_1 = new Maze(grid);                      // World initialized with the Grid

            // Initializing a new Player
            currentPlayer = new MazeRunner(8,1);               // Player initialized with the Grid-Position

            RunGameLoop();
        }

        private void DrawWorld()
        {
            Console.Clear();
            world_1.Draw();                                 // Draw the new Playground
            currentPlayer.Draw();                           // Draw the new Player
        }

        private void RunGameLoop()
        {
            while (true)
            {
                // Initial Drawings
                DrawWorld();

                // Using Arrow Keys
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if(world_1.isWalkable(currentPlayer.Y, currentPlayer.X-1))
                        {
                            //currentPlayer.MoveThomasUp();
                            currentPlayer.X -= 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (world_1.isWalkable(currentPlayer.Y, currentPlayer.X+1))
                        {
                            //currentPlayer.MoveThomasDown();
                            currentPlayer.X += 1;
                        }                            
                        break;
                    case ConsoleKey.LeftArrow:
                        if (world_1.isWalkable(currentPlayer.Y-1, currentPlayer.X))
                        {
                            //currentPlayer.MoveThomasLeft();
                            currentPlayer.Y -= 1;
                        }                           
                        break;
                    case ConsoleKey.RightArrow:
                        if (world_1.isWalkable(currentPlayer.Y+1, currentPlayer.X))
                        {
                            //currentPlayer.MoveThomasRight();
                            currentPlayer.Y += 1;
                        }                            
                        break;
                    default: break;
                }

                // Ending the Game
                //string currentPosition = world_1.ElementPosition(currentPlayer.X, currentPlayer.Y);
                //if (currentPosition == "X")
                //{
                //    break;
                //}


                System.Threading.Thread.Sleep(50);
            }

        }
    }
}
