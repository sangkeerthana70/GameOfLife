using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifeWebApplication;
using GameOfLifeWebApplication.Models;

namespace GameOfLifeTests
{
    [TestFixture]
    public class Tests
    {
        //bool[,] game = new bool[3, 3];
       [Test] 
        public void returnGrid()
        {
            bool[,] input = new bool[3,3];
            bool[,] output = Grid.GameOfLifeLogic(input);
            bool[,] expected = input;
            Assert.AreEqual(expected, output);

        }

        [Test]
        public void EachCellAdjacentToExactlyThreeLiveNeighborsBecomesAlive()
        {
            bool[,] input = new bool[3, 3]
            {
                {false, true, false },
                {true, true, false},
                {false, false, false }

            };
            bool[,] output = Grid.GameOfLifeLogic(input);
            bool[,] expected = new bool[3, 3]
            {
                {true, true, false },
                {true, true, false},
                {false, false, false }
            };
            Assert.AreEqual(expected, output);
        }
 

    }
}
