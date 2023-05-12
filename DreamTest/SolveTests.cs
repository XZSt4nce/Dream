using dream;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DreamTest
{
    [TestClass]
    public class SolveTests
    {
        [TestMethod]
        public void SolveTest1()
        {
            char[,] maze = new char[,]
            {
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
                { 'X', 'S', '.', '.', 'Y', 'G', 'B', '.', '.', '.', '.', 'X' },
                { 'X', '.', '.', 'X', 'X', 'X', 'R', 'X', 'X', 'X', '.', 'X' },
                { 'X', '.', 'Y', 'G', '.', '.', 'E', 'Y', '.', '.', '.', 'X' },
                { 'X', '.', 'X', '.', '.', '.', 'Y', '.', '.', '.', '.', 'X' },
                { 'X', '.', 'X', 'X', 'X', '.', 'X', '.', '.', '.', '.', 'X' },
                { 'X', '.', 'Y', '.', '.', '.', 'X', '.', '.', '.', '.', 'X' },
                { 'X', 'X', '.', 'X', 'X', 'X', 'X', '.', '.', '.', '.', 'X' },
                { 'X', 'X', '.', 'Y', 'G', '.', '.', '.', '.', '.', '.', 'X' },
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' }
            };
            Dream test = new Dream(maze)
            {
                R = 3,
                G = 4,
                B = 5,
                Y = 6
            };
            test.ScanNodes();
            test.ScanPaths();
            test.PathsColorization();
            Assert.IsTrue(test.Paths.Count > 0, "Not enough paths");
            Path first = test.Paths[0];
            int min = Convert.ToInt32(first.Red) * test.R +
                      Convert.ToInt32(first.Green) * test.G +
                      Convert.ToInt32(first.Blue) * test.B +
                      Convert.ToInt32(first.Yellow) * test.Y;
            for (int i = 1; i < test.Paths.Count; i++)
            {
                Path path = test.Paths[i];
                int cost = Convert.ToInt32(path.Red) * test.R +
                           Convert.ToInt32(path.Green) * test.G +
                           Convert.ToInt32(path.Blue) * test.B +
                           Convert.ToInt32(path.Yellow) * test.Y;
                if (cost < min) min = cost;
            }
            Assert.IsTrue(min == 10, "Wrong min cost");
        }
    }
}
