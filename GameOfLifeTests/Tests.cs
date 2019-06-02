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
       [Test] 
        public void returnGrid()
        {

            bool[,] input = new bool[3, 3]
            {
                {false, true, false },
                {true, true, false},
                {false, false, false }

            };
            bool[,] expected = input;
            bool[,] output = Grid.ChangeState(input);
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
            bool[,] output = Grid.ChangeState(input);
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
