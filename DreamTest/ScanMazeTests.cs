using Microsoft.VisualStudio.TestTools.UnitTesting;
using dream;

namespace DreamTest
{
    [TestClass]
    public class ScanMaze
    {
        [TestMethod]
        public void ScanMazeTest1()
        {
            char[,] maze = new char[,]
            {
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
                { 'X', '.', 'X', '.', '.', 'E', 'X' },
                { 'X', '.', 'X', '.', 'X', 'R', 'X' },
                { 'X', 'X', 'X', '.', 'X', '.', 'X' },
                { 'X', 'S', '.', '.', '.', '.', 'X' },
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X' }
            };
            Dream test = new Dream(maze);
        }
    }
}
