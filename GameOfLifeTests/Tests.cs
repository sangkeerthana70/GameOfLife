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
        // Births: Each dead cell adjacent to exactly three live neighbors will become live in the next generation.
        public void EachDeadCellAdjacentTo_ExactlyThreeLiveNeighborsBecomesAlive()
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
        
        [Test]
        //Survival: Each live cell with either two or three live neighbors will remain alive for the next generation.
        public void EachLiveCellWith_EitherTwoOrThreeLiveNeighborsWillRemainAlive()
        {
            bool[,] input = new bool[5, 5]
            {
                { true, false, false, false, false },
                { true, true, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false }

            };
            bool[,] actual = Grid.ChangeState(input);
            bool[,] expected = new bool[5, 5]
            {

                { true, true, false, false, false },
                { true, true, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false }


            };
            Assert.AreEqual(expected, actual);

        }

        [Test]
        //Death by isolation: Each live cell with one or fewer live neighbors will die in the next generation.
        public void EachLiveCellWith_OneOrFewerLiveNeighborsWillDiebyIsolation()
        {
            bool[,] input = new bool[5, 5]
           {
                { true, false, false, false, false },
                { true, true, false, false, false },
                { false, false, false, false, false },
                { false, false, false, true, false },
                { false, false, false, false, true }

           };
            bool[,] actual = Grid.ChangeState(input);
            bool[,] expected = new bool[5, 5]
            {

                { true, true, false, false, false },
                { true, true, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false },
                { false, false, false, false, false }


            };
            Assert.AreEqual(expected, actual);
        }

        [Test]

        // Death by overcrowding: Each live cell with four or more live neighbors will die in the next generation.
        public void EachLiveCellWith_FourOrMoreLiveNeighborsWillDieByOverCrowding()
        {
            bool[,] input = new bool[7, 7]
            {
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false},
                { false, false, true, true, true, false, false },
                { false, false, true, true, true, false, false },
                { false, false, false, true, true, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false }

            };

            bool[,] actual = Grid.ChangeState(input);
            bool[,] expected = new bool[7, 7]
            {
               { false, false, false, false, false, false, false },
                { false, false, false, true, false, false, false },
                { false, false, true, false, true, false, false },
                { false, false, false, false, false, true, false },
                { false, false, true, false, true, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false }


            };
            Assert.AreEqual(expected, actual);
        }
       

    }
}
