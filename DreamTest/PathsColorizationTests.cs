using dream;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DreamTest
{
    [TestClass]
    public class PathsColorizationTests
    {
        public bool Compare(Path[] expected, Path[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i].Red != actual[i].Red) return false;
                if (expected[i].Green != actual[i].Green) return false;
                if (expected[i].Blue != actual[i].Blue) return false;
                if (expected[i].Yellow != actual[i].Yellow) return false;
            }
            return true;
        }
        [TestMethod]
        public void PathsColorizationTest1()
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
            test.ScanNodes();
            test.ScanPaths();
            Path[] expected = test.Paths.Values.ToArray();
            test.PathsColorization();
            expected[1].Red = true;
            Assert.IsTrue(Compare(expected, test.Paths.Values.ToArray()));
        }

        [TestMethod]
        public void PathsColorizationTest2()
        {
            char[,] maze = new char[,]
            {
                { 'X', 'X', 'X', 'X', 'X', 'X' },
                { 'X', 'S', '.', 'X', '.', 'X' },
                { 'X', '.', '.', 'R', '.', 'X' },
                { 'X', '.', 'X', 'X', 'B', 'X' },
                { 'X', '.', 'G', '.', 'E', 'X' },
                { 'X', 'X', 'X', 'X', 'X', 'X' }
            };
            Dream test = new Dream(maze);
            test.ScanNodes();
            test.ScanPaths();
            Path[] expected = test.Paths.Values.ToArray();
            test.PathsColorization();
            expected[0].Green = true;
            expected[1].Red = true;
            expected[1].Blue = true;
            Assert.IsTrue(Compare(expected, test.Paths.Values.ToArray()));
        }
    }
}
