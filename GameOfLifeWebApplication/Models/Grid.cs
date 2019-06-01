using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLifeWebApplication.Models
{
    public class Grid
    {
        public bool[,] grid;
        public int generation = 0;

        public Grid(int rows, int columns)
        {
            this.grid = new bool[rows, columns];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    this.grid[i, j] = false;
                }
            }
        }


        public static bool [,] GameOfLifeLogic(bool[,]game)
        {
            int counter = 0;
            for(int i = 0; i < game.GetLength(0) -2; i++)
            {
                for (int j = 0; j < game.GetLength(1)-2; j++)
                {
                    if(game[i,j] == false)
                    {
                        Console.WriteLine("Inside if");
                        if(game[i, j+1] == true && game[i+1, j] == true && game[i+1, j+1] == true)
                        {
                            
                            game[i, j] = true;
                            Console.WriteLine("game[i,j] " + game[i,j]);
                            break;
                        }
                    }
                }
            }
            

            return game;
        }


    }
}