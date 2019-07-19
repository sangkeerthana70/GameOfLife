using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLifeWebApplication.Models
{
    public class Grid
    {
        public bool[,] grid { get; set; }
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


        public static bool [,] ChangeState(bool[,]gamestate)
        {
            int neighbors = 0;
            bool[,] gamestateCopy = new bool[gamestate.GetLength(0), gamestate.GetLength(1)];

            for (int i = 0; i < gamestate.GetLength(0); i++)
            {
                for (int j = 0; j < gamestate.GetLength(1); j++)
                {
                    gamestateCopy[i, j] = gamestate[i, j];
                }
            }

            for(int i = 0; i < gamestate.GetLength(0); i++)
            {
                for(int j = 0; j < gamestate.GetLength(1); j++)
                {
                    Console.WriteLine("i = {0}, j = {1} , Value = {2} ", i, j, gamestate[i, j]);
                    neighbors = GetActiveNeighbors(i, j, gamestateCopy);
                    Console.WriteLine("neighbors " + neighbors);


                    if(gamestate[i, j] == true)
                    {
                        if ((neighbors == 2) || (neighbors == 3))
                        {
                            gamestate[i, j] = true;
                        }
                        else
                        {
                            gamestate[i, j] = false;
                        }
                            
                    }
                    else
                    {
                        if(neighbors == 3)
                        {
                            gamestate[i, j] = true;
                        }
                    }
                }
                
            }

            return gamestate;
        }

        private static int GetActiveNeighbors(int i, int j, bool[,] gameState)
        {
            int rowStart = 0;
            int rowEnd = 0;
            int columnStart = 0;
            int columnEnd = 0;

            if (i == 0)            
                rowStart = i;           
            else
                rowStart = i - 1;

            if (j == 0)
                columnStart = j;
            else
                columnStart = j - 1;

            if (i == gameState.GetLength(0) - 1)
                rowEnd = i;
            else
                rowEnd = i + 1;

            if (j == gameState.GetLength(1) - 1)
                columnEnd = j;
            else
                columnEnd = j + 1;

            Console.WriteLine("rowStart: " + rowStart);
            Console.WriteLine("rowEnd: " + rowEnd);
            Console.WriteLine("colStart " + columnStart);
            Console.WriteLine("colEnd " + columnEnd);
            int neighbors = 0;
            
            for(int x = rowStart; x <= rowEnd; x++)
            {
                for(int y = columnStart; y <= columnEnd; y++)
                {
                    Console.WriteLine("x={0},y={1},value = {2}",x,y,gameState[x,y]);
                    if((x == i) && (y == j))
                    {
                        continue;
                    }

                    if(gameState[x, y] == true)
                        neighbors++;

                    Console.WriteLine("neighbour={0}", neighbors);

                }
            }

            return neighbors;

        }

    }
}